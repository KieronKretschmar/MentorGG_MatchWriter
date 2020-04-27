using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.Producer;
using RabbitCommunicationLib.Queues;
using RabbitCommunicationLib.TransferModels;
using StackExchange.Redis;

namespace MatchWriter
{
    /// <summary>
    /// Requires env variables ["MYSQL_CONNECTION_STRING", "AMQP_URI","AMQP_DEMOFILEWORKER_QUEUE", "AMQP_CALLBACK_QUEUE"]
    /// </summary>
    public class Startup
    {
        private const ushort AMQP_PREFETCH_COUNT_DEFAULT = 1;
        private const string AMQP_EXCHANGE_CONSUME_QUEUE_DEFAULT = "MW_ConsumeQueue";

        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Logging
            services.AddLogging(o =>
            {
                o.AddConsole(options =>
                {
                    options.TimestampFormat = "[yyyy-MM-dd HH:mm:ss zzz] ";
                });

                //Filter out ASP.Net and EFCore logs of LogLevel lower than LogLevel.Warning
                o.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
                o.AddFilter("Microsoft.EntityFrameworkCore.Infrastructure", LogLevel.Warning);
                o.AddFilter("Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker", LogLevel.Warning);
                o.AddFilter("Microsoft.AspNetCore.Mvc.Infrastructure.ObjectResultExecutor", LogLevel.Warning);
                o.AddFilter("Microsoft.AspNetCore.Hosting.Diagnostics", LogLevel.Warning);
                o.AddFilter("Microsoft.AspNetCore.Routing.EndpointMiddleware", LogLevel.Warning);
            });
            #endregion

            #region Mysql Database
            var MYSQL_CONNECTION_STRING = Configuration.GetValue<string>("MYSQL_CONNECTION_STRING");
            // if a connectionString is set use mysql, else use InMemory
            if (MYSQL_CONNECTION_STRING != null)
            {
                // Add context as Transient instead of Scoped, as Scoped lead to DI error and does not have advantages under non-http conditions
                services.AddDbContext<Database.MatchContext>(o => { o.UseMySql(MYSQL_CONNECTION_STRING); }, ServiceLifetime.Transient, ServiceLifetime.Transient);
            }
            else
            {
                Console.WriteLine("WARNING: Using InMemoryDatabase!");

                services.AddEntityFrameworkInMemoryDatabase()
                    .AddDbContext<Database.MatchContext>((sp, options) =>
                    {
                        options.UseInMemoryDatabase(databaseName: "MyInMemoryDatabase").UseInternalServiceProvider(sp);
                    }, ServiceLifetime.Transient, ServiceLifetime.Transient);
            }

            if (Configuration.GetValue<bool>("IS_MIGRATING"))
            {
                Console.WriteLine("WARNING: IS_MIGRATING is true. This should not happen in production.");
                return;
            }
            #endregion

            #region Rabbit
            // Read environment variables
            var AMQP_URI = GetRequiredEnvironmentVariable<string>(Configuration, "AMQP_URI");
            var AMQP_CALLBACK_QUEUE = GetRequiredEnvironmentVariable<string>(Configuration, "AMQP_CALLBACK_QUEUE");
            var AMQP_EXCHANGE_NAME = GetRequiredEnvironmentVariable<string>(Configuration, "AMQP_EXCHANGE_NAME");
            var AMQP_PREFETCH_COUNT = GetOptionalEnvironmentVariable<ushort>(Configuration, "AMQP_PREFETCH_COUNT", AMQP_PREFETCH_COUNT_DEFAULT);
            var AMQP_EXCHANGE_CONSUME_QUEUE = GetOptionalEnvironmentVariable<string>(Configuration, "AMQP_EXCHANGE_CONSUME_QUEUE", AMQP_EXCHANGE_CONSUME_QUEUE_DEFAULT);
            var AMQP_DEMOCENTRAL_DEMO_REMOVAL = GetRequiredEnvironmentVariable<string>(Configuration, "AMQP_DEMOCENTRAL_DEMO_REMOVAL");
            var AMQP_DEMOCENTRAL_DEMO_REMOVAL_REPLY = GetRequiredEnvironmentVariable<string>(Configuration, "AMQP_DEMOCENTRAL_DEMO_REMOVAL_REPLY");

            // Setup Producer
            var callbackQueue = new QueueConnection(AMQP_URI, AMQP_CALLBACK_QUEUE);
            services.AddTransient<IProducer<TaskCompletedReport>>(sp =>
            {
                return new Producer<TaskCompletedReport>(callbackQueue);
            });

            // Setup Consumer
            var exchangeQueue = new ExchangeQueueConnection(AMQP_URI, AMQP_EXCHANGE_NAME, AMQP_EXCHANGE_CONSUME_QUEUE);
            services.AddHostedService<MatchDataConsumer>(serviceProvider =>
            {
                return new MatchDataConsumer(
                    serviceProvider,
                    exchangeQueue,
                    AMQP_PREFETCH_COUNT);
            });


            var demoCentralRPCqueues = new RPCQueueConnections(AMQP_URI, AMQP_DEMOCENTRAL_DEMO_REMOVAL, AMQP_DEMOCENTRAL_DEMO_REMOVAL_REPLY);
            services.AddHostedService<IDemoCentral>(services =>
            {
                return new DemoCentral(demoCentralRPCqueues, services.GetRequiredService<IDatabaseHelper>(), services.GetRequiredService<ILogger<DemoCentral>>());
            });

            #endregion

            #region Redis
            var REDIS_CONFIGURATION_STRING = Configuration.GetValue<string>("REDIS_CONFIGURATION_STRING");
            if(REDIS_CONFIGURATION_STRING == "mock")
            {
                // Add MockRedis, a local InMemory redis cache good for testing
                services.AddTransient<IMatchRedis, MockRedis>();
            }
            else
            {
                // Add ConnectionMultiplexer as singleton as it is made to be reused
                // see https://stackexchange.github.io/StackExchange.Redis/Basics.html
                services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(REDIS_CONFIGURATION_STRING));
                services.AddTransient<IMatchRedis, MatchRedis>();
            }
            #endregion

            #region Helpers
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            #endregion

            
            #region Swagger
            services.AddSwaggerGen(options =>
            {
                OpenApiInfo interface_info = new OpenApiInfo { Title = "MatchRetriever", Version = "v1", };
                options.SwaggerDoc("v1", interface_info);

                // Generate documentation based on the XML Comments provided.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                // Optionally, if installed, enable annotations
                options.EnableAnnotations();
            });            
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "MatchRetriever");
            });
            #endregion

            // migrate if this is not an inmemory database
            if (services.GetRequiredService<MatchContext>().Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                services.GetRequiredService<MatchContext>().Database.Migrate();
            }
        }

        /// <summary>
        /// Attempt to retrieve an Environment Variable
        /// Throws ArgumentNullException is not found.
        /// </summary>
        /// <typeparam name="T">Type to retreive</typeparam>
        private static T GetRequiredEnvironmentVariable<T>(IConfiguration config, string key)
        {
            T value = config.GetValue<T>(key);
            if (value == null)
            {
                throw new ArgumentNullException(
                    $"{key} is missing, Configure the `{key}` environment variable.");
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Attempt to retrieve an Environment Variable
        /// Returns default value if not found.
        /// </summary>
        /// <typeparam name="T">Type to retreive</typeparam>
        private static T GetOptionalEnvironmentVariable<T>(IConfiguration config, string key, T defaultValue)
        {
            var stringValue = config.GetSection(key).Value;
            try
            {
                T value = (T) Convert.ChangeType(stringValue, typeof(T), System.Globalization.CultureInfo.InvariantCulture);
                return value;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine($"Env var [ {key} ] not specified. Defaulting to [ {defaultValue} ]");
                return defaultValue;
            }
        }
    }
}
