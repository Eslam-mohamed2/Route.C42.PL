using BLL_Business_Logic_Layer_.Interfaces;
using BLL_Business_Logic_Layer_.Repositories;
using Data_Access_Layer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) // To Allow The depands Injection to DbContext 
        {
            services.AddControllersWithViews(); // Register Built in services Required by MVC
                                                //services.AddRazorPages(); // Register Common use Feature in Razer Pages
                                                //services.AddMvc(); // If u wanna make your Project MVC / Razer Pages / Web APIs
            services.AddDbContext<ApplicationDbContext>(Options => {
                Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); 
            });
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddTransient<ApplicationDbContext>();
            //services.AddScoped<ApplicationDbContext>();
            //services.AddScoped<DbContextOptions<ApplicationDbContext>>();
            //services.AddSingleton<ApplicationDbContext>();

            //services.AddDbContext<ApplicationDbContext>(); // if i Didn't Select The Life Time It Will Be By Default -> [escoped]  
            //contextLifetime: ServiceLifetime.Singleton,
            //optionsLifetime: ServiceLifetime.Singleton
            //);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
