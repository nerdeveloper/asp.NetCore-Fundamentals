using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using odetofood.Services;
using odetofood.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace odetofood
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables();
           Configuration = builder.Build();

        }
        public IConfiguration Configuration
        {
            get;
            set;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, SqlResturantData>();
            services.AddDbContext<OdeToFoodDB>(options => options.UseSqlServer(Configuration.GetConnectionString("odetoFood")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<OdeToFoodDB>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseIdentity();
            app.UseMvc(configureRoutes);

            app.Run(ctx => ctx.Response.WriteAsync("Not Found!"));
            //app.Run(async (context) =>
            //{
            //   // throw new Exception("Something went wrong!");
            //    var message = greeter.GetGreeting();
            //    await context.Response.WriteAsync(message);
            //}
            //);
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {

            //Home ?index
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
