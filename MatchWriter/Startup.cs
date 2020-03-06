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

            services.AddScoped<IDatabaseHelper, DatabaseHelper>();
            services.AddSingleton<IMatchRedis, MatchRedis>();

            // if a connectionString is set use mysql, else use InMemory
            var MYSQL_CONNECTION_STRING = Configuration.GetValue<string>("MYSQL_CONNECTION_STRING");
            if (MYSQL_CONNECTION_STRING == null)
                throw new ArgumentException("MYSQL_CONNECTION_STRING is missing, configure the `MYSQL_CONNECTION_STRING` enviroment variable. Defaulting to InMemory database.");

            if (MYSQL_CONNECTION_STRING != null)
            {
                services.AddDbContext<Database.MatchContext>(o => { o.UseMySql(MYSQL_CONNECTION_STRING); });
            }
            else
            {
                services.AddEntityFrameworkInMemoryDatabase()
                    .AddDbContext<Database.MatchContext>((sp, options) =>
                    {
                        options.UseInMemoryDatabase(databaseName: "MyInMemoryDatabase").UseInternalServiceProvider(sp);
                    });
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
            var AMQP_CALLBACK_QUEUE = Configuration.GetValue<string>("AMQP_CALLBACK_QUEUE");
            if (AMQP_CALLBACK_QUEUE == null)
                throw new ArgumentException("AMQP_CALLBACK_QUEUE is missing, configure the `AMQP_CALLBACK_QUEUE` enviroment variable.");

            var callbackQueue = new QueueConnection(AMQP_URI, AMQP_CALLBACK_QUEUE);
            services.AddSingleton<IProducer<TaskCompletedTransferModel>>(sp =>
            {
                return new Producer<TaskCompletedTransferModel>(callbackQueue);
            });

            // Setup rabbit - Create consumer
            var AMQP_DEMOFILEWORKER_QUEUE = Configuration.GetValue<string>("AMQP_DEMOFILEWORKER_QUEUE");
            if (AMQP_DEMOFILEWORKER_QUEUE == null)
                throw new ArgumentException("AMQP_DEMOFILEWORKER_QUEUE is missing, configure the `AMQP_DEMOFILEWORKER_QUEUE` enviroment variable.");

            var incomingQueue = new QueueConnection(AMQP_URI, AMQP_DEMOFILEWORKER_QUEUE);
            services.AddHostedService<DemoFileWorkerConsumer>(services =>
            {
                return new DemoFileWorkerConsumer(
                    incomingQueue, 
                    services.GetRequiredService<ILogger<DemoFileWorkerConsumer>>(), 
                    services.GetRequiredService<IDatabaseHelper>(), 
                    services.GetRequiredService<IProducer<TaskCompletedTransferModel>>(),
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
