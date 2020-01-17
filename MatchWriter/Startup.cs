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
using RabbitTransfer.Interfaces;
using RabbitTransfer.Producer;
using RabbitTransfer.Queues;
using RabbitTransfer.TransferModels;

namespace MatchWriter
{
    /// <summary>
    /// Requires env variables ["AMQP_URI","AMQP_DEMOFILEWORKER_QUEUE", "AMQP_CALLBACK_QUEUE"]
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
            services.AddLogging(x => x.AddConsole().AddDebug());

            services.AddScoped<IDatabaseHelper, DatabaseHelper>();
            services.AddScoped<IMatchRedis, MatchRedis>();

            // if a connectionString is set use mysql, else use InMemory
            var connString = Configuration.GetValue<string>("MYSQL_CONNECTION_STRING");
            Console.WriteLine($"connString {connString}");
            if (connString != null)
            {
                services.AddDbContext<Database.MatchContext>(o => { o.UseMySql(connString); });
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
                Console.WriteLine("IS_MIGRATING is true. This should not happen in production.");
                return;
            }

            // Setup rabbit
            var AMQP_URI = Configuration.GetValue<string>("AMQP_URI");

            // Setup rabbit - Create producer
            var AMQP_CALLBACK_QUEUE = Configuration.GetValue<string>("AMQP_CALLBACK_QUEUE");
            var callbackQueue = new QueueConnection(AMQP_URI, AMQP_CALLBACK_QUEUE);
            services.AddSingleton<IProducer<TaskCompletedTransferModel>>(sp =>
            {
                return new Producer<TaskCompletedTransferModel>(callbackQueue);
            });

            // Setup rabbit - Create consumer
            var AMQP_DEMOFILEWORKER_QUEUE = Configuration.GetValue<string>("AMQP_DEMOFILEWORKER_QUEUE");
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
