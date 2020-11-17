using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Api.Data;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(p=>p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            // var server = Environment.GetEnvironmentVariable("DATABASE_URL"); 
            // Console.WriteLine(server);

            // services.AddDbContext<DataContext>(options => {
                
            //     string connStr;

            //     var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            //     connUrl = connUrl.Replace("postgres://", string.Empty);
            //     var pgUserPass = connUrl.Split("@")[0];
            //     var pgHostPortDb = connUrl.Split("@")[1];
            //     var pgHostPort = pgHostPortDb.Split("/")[0];
            //     var pgDb = pgHostPortDb.Split("/")[1];
            //     var pgUser = pgUserPass.Split(":")[0];
            //     var pgPass = pgUserPass.Split(":")[1];
            //     var pgHost = pgHostPort.Split(":")[0];
            //     var pgPort = pgHostPort.Split(":")[1];
            //     connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};SslMode=Require;";

            //     Console.WriteLine(connStr);
            //     options.UseNpgsql(connStr);

            // });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
