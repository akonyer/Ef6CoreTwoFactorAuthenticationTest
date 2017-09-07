#region Includes

using System;
using System.Data.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MR.AspNet.Identity.EntityFramework6;
using TwoFactorAuthTest.Data;
using TwoFactorAuthTest.Models;
using TwoFactorAuthTest.Services;
using TwoFactorAuthTest.Settings;

#endregion

namespace TwoFactorAuthTest
{
   public class Startup
   {
      #region Constructor(s), Destructor, and Dispose

      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      #endregion
      #region Properties

      public IConfiguration Configuration { get; }

      #endregion
      #region Methods

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if(env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
         }

         app.UseStaticFiles();

         app.UseAuthentication();

         app.UseMvc(
            routes =>
            {
               routes.MapRoute(
                  "default",
                  "{controller=Home}/{action=Index}/{id?}");
            });
      }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddScoped<ApplicationDbContext>();

         Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
         ApplicationDbContext.ConnectionString = SiteSettings.ConnectionString;

         services.AddIdentity<ApplicationUser, IdentityRole>(
               d =>
               {
                  d.Lockout.AllowedForNewUsers = true;
                  d.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                  d.Lockout.MaxFailedAccessAttempts = 5;
                  d.User.RequireUniqueEmail = true;
                  d.Password.RequireNonAlphanumeric = false;
                  d.Password.RequireUppercase = false;
                  d.Password.RequireLowercase = false;
                  d.Password.RequireDigit = true;
                  d.Password.RequiredLength = 6;
               })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

         // Add application services.
         services.AddTransient<IEmailSender, EmailSender>();

         services.AddMvc();
      }

      #endregion
   }
}