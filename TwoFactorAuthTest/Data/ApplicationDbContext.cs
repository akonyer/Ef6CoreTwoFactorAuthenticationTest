using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MR.AspNet.Identity.EntityFramework6;
using TwoFactorAuthTest.Models;
using TwoFactorAuthTest.Settings;

namespace TwoFactorAuthTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

       public static string ConnectionString { get; set; }

       public ApplicationDbContext()
          : base(ConnectionString)
       { }

      protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
