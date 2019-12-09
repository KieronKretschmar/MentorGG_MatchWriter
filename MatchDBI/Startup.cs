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

namespace MatchDBI
{
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

            // if a connectionString is set use mysql, else use InMemory
            var connString = Configuration.GetValue<string>("ConnectionString");
            if (connString != null)
            {
                services.AddDbContext<Database.MatchContext>(o => { o.UseMySql(connString); });
            }
            else
            {
                // TODO: Add InMemoryDatabase (below don't work due to problems with dependencies)

                //services.AddDbContext<Database.MatchContext>(o => { o.UseInMemoryDatabase("MyDatabase"); });
                //services.AddEntityFrameworkInMemoryDatabase()
                //    .AddDbContext<Database.MatchContext>((sp, options) =>
                //    {
                //        options.UseInMemoryDatabase().UseInternalServiceProvider(sp);
                //    });
            }
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
