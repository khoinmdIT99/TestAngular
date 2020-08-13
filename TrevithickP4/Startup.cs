//James Trevithick          jtrevithick2@cnm.edu                TrevithickP4
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrevithickP4.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrevithickP4.Models;
using System.IO;

namespace TrevithickP4
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedDatabaseAsync(serviceProvider).Wait();
        }

        private async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            //get reference of dbcontext
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();


            if (context != null)
            {
                //I need to make my own csvReader class in order to make the program work 
                //could not find others that would work with my csv. James Trevithick
                TextReader textReader = File.OpenText("Campaign-old.csv");
                CsvReader csv = new CsvReader(textReader);
                csv.Delimiter = '\t';
                List<Campaign> records = csv.GetRecords();
                foreach (var r in records)
                {
                    //add to the list of campaign
                    context.Add<Campaign>(r);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
