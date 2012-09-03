using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Util
{
    public sealed class ConfigUtil
    {
        public static string GetString(string arg0)
        {
            return 
                System.Configuration.ConfigurationManager.AppSettings.Get(arg0);
        }

        public static int GetInt(string arg0)
        {
            return int.Parse(System.Configuration.ConfigurationManager.AppSettings.Get(arg0));
        }

        public static decimal GetDecimal(string arg0)
        {
            return decimal.Parse(System.Configuration.ConfigurationManager.AppSettings.Get(arg0));
        }

    }
}
