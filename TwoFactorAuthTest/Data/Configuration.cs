using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace TwoFactorAuthTest.Data
{
    public class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
   {
      #region Constructor(s), Destructor, and Dispose

      public Configuration()
      {
         AutomaticMigrationsEnabled = true;
         AutomaticMigrationDataLossAllowed = true;
      }

      #endregion
      #region Methods

      protected override void Seed(ApplicationDbContext context)
      { }

      #endregion
   }
}
