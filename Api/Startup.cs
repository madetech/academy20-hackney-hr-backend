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
using Api.Models;
using Npgsql;

namespace Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_URL");
            services.AddDbContext<AppDbContext>(options =>
            {
                // // for remote db Heroku
                // string connStr; 

                // // for local db development
                string connStr = "host=localhost; port=5432; user id=postgres; password=admin; database=postgres; pooling = true";

                // // remote db Heroku
                // var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                // connUrl = connUrl.Replace("postgres://", string.Empty);
                // var pgUserPass = connUrl.Split("@")[0];
                // var pgHostPortDb = connUrl.Split("@")[1];
                // var pgHostPort = pgHostPortDb.Split("/")[0];
                // var pgDb = pgHostPortDb.Split("/")[1];
                // var pgUser = pgUserPass.Split(":")[0];
                // var pgPass = pgUserPass.Split(":")[1];
                // var pgHost = pgHostPort.Split(":")[0];
                // var pgPort = pgHostPort.Split(":")[1];
                // connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};SSL Mode=Require; Trust Server Certificate=true;";

                var builder = new NpgsqlConnectionStringBuilder(connStr);

                Console.WriteLine(builder.ConnectionString);
                options.UseNpgsql(builder.ConnectionString);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000",
                    "https://hackney-council-hr.herokuapp.com").AllowAnyHeader().AllowAnyMethod();
                });
            });

            
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
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();
            // app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
