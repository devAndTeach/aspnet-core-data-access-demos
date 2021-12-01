using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFWebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFWebApp
{
    public class Startup
    { public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=HumanResources;Trusted_Connection=True;";
            services.AddDbContext<HrContext>(options => 
                            options.UseSqlServer(connectionString));
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, HrContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=HumanResources}/{action=Candidates}");
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller="Students",action="Index" });
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
