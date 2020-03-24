using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.Producer;
using RabbitCommunicationLib.Queues;
using RabbitCommunicationLib.TransferModels;

namespace MatchWriter
{
    /// <summary>
    /// Requires env variables ["MYSQL_CONNECTION_STRING", "AMQP_URI","AMQP_DEMOFILEWORKER_QUEUE", "AMQP_CALLBACK_QUEUE"]
    /// </summary>
    public class Startup
    {
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

            services.AddLogging(services =>
            {
                services.AddConsole(o =>
                {
                    o.TimestampFormat = "[yyyy-MM-dd HH:mm:ss zzz] ";
                });
                services.AddDebug();
            });

            var REDIS_URI = Configuration.GetValue<string>("REDIS_URI");

            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IMatchRedis>(sp =>
            {
                if (REDIS_URI == "mock")
                    return new MockRedis();
                else
                    return new MatchRedis(sp.GetRequiredService<ILogger<MatchRedis>>(),REDIS_URI);
            });

            // if a connectionString is set use mysql, else use InMemory
            var MYSQL_CONNECTION_STRING = Configuration.GetValue<string>("MYSQL_CONNECTION_STRING");

            if (MYSQL_CONNECTION_STRING != null)
            {
                // Add context as Transient instead of Scoped, as Scoped lead to DI error and does not have advantages under non-http conditions
                services.AddDbContext<Database.MatchContext>(o => { o.UseMySql(MYSQL_CONNECTION_STRING); }, ServiceLifetime.Transient);
            }
            else
            {
                Console.WriteLine("WARNING: Using InMemoryDatabase!");

                services.AddEntityFrameworkInMemoryDatabase()
                    .AddDbContext<Database.MatchContext>((sp, options) =>
                    {
                        options.UseInMemoryDatabase(databaseName: "MyInMemoryDatabase").UseInternalServiceProvider(sp);
                    }, ServiceLifetime.Transient);
            }

            if (Configuration.GetValue<bool>("IS_MIGRATING"))
            {
                Console.WriteLine("WARNING: IS_MIGRATING is true. This should not happen in production.");
                return;
            }

            // Setup rabbit
            var AMQP_URI = Configuration.GetValue<string>("AMQP_URI");
            if (AMQP_URI == null)
                throw new ArgumentException("AMQP_URI is missing, configure the `AMQP_URI` enviroment variable.");

            // Setup rabbit - Create producer
            var AMQP_CALLBACK_QUEUE = Configuration.GetValue<string>("AMQP_CALLBACK_QUEUE") 
                ?? throw new ArgumentException("AMQP_CALLBACK_QUEUE is missing, configure the `AMQP_CALLBACK_QUEUE` enviroment variable.");

            var callbackQueue = new QueueConnection(AMQP_URI, AMQP_CALLBACK_QUEUE);
            services.AddTransient<IProducer<TaskCompletedReport>>(sp =>
            {
                return new Producer<TaskCompletedReport>(callbackQueue);
            });

            // Setup rabbit - Create consumer
            var AMQP_EXCHANGE_NAME = Configuration.GetValue<string>("AMQP_EXCHANGE_NAME")
               ?? throw new ArgumentException("AMQP_EXCHANGE_NAME is missing, configure the `AMQP_EXCHANGE_NAME` enviroment variable.");

            var AMQP_EXCHANGE_CONSUME_QUEUE = Configuration.GetValue<string>("AMQP_EXCHANGE_CONSUME_QUEUE");
            if (AMQP_EXCHANGE_CONSUME_QUEUE is null)
            {
                var defaultQueue = "MW_ConsumeQueue"; 
                Console.WriteLine($"No name for AMQP_EXCHANGE_CONSUME_QUEUE has been set, defaulting to {defaultQueue}");
                AMQP_EXCHANGE_CONSUME_QUEUE = defaultQueue;
            }

            var exchangeQueue = new ExchangeQueueConnection(AMQP_URI,AMQP_EXCHANGE_NAME, AMQP_EXCHANGE_CONSUME_QUEUE);
            services.AddHostedService<MatchFanOutConsumer>(services =>
            {
                return new MatchFanOutConsumer(
                    exchangeQueue, 
                    services.GetRequiredService<ILogger<MatchFanOutConsumer>>(), 
                    services.GetRequiredService<IDatabaseHelper>(), 
                    services.GetRequiredService<IProducer<TaskCompletedReport>>(),
                    services.GetRequiredService<IMatchRedis>());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        }
    }
}
