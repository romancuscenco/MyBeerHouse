using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MB.TheBeerHouse
{
    public static class Globals
    {
        public static string ThemesSelectorID = string.Empty;
        public readonly static TheBeerHouseSection Settings = (TheBeerHouseSection)WebConfigurationManager.GetSection("theBeerHouse");
    }
}