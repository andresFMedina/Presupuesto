using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presupuesto.Middlewares;
using Presupuesto.Models;

namespace Presupuesto
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
            services.AddDbContextPool<PresupuestoContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("PresupuestoDbConnection")));
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();

                        /*builder.WithOrigins("https://presup.azurewebsites.net")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();*/
                    }
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOptions();
            app.UseCors("AllowOrigin");
            app.UseDeveloperExceptionPage();

            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }   */        

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
