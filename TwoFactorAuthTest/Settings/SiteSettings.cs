using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoFactorAuthTest.Settings
{
    public static class SiteSettings
    {
      public static string ConnectionString { get; set; } = "Server=(local);Database=TwoFactorAuthTest;Trusted_Connection=True;MultipleActiveResultSets=true";

   }
}
