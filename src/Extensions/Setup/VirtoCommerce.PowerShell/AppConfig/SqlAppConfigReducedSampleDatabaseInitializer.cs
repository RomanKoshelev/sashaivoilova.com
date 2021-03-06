﻿using System.Linq;

namespace VirtoCommerce.PowerShell.AppConfig
{
    public class SqlAppConfigReducedSampleDatabaseInitializer : SqlAppConfigSampleDatabaseInitializer
    {
        protected override string[] GetSampleFiles()
        {
            var retVal = base.GetSampleFiles().ToList();
            retVal.Remove("Localization.sql");
            retVal.Add("Localization.reduced.sql");
            return retVal.ToArray();
        }
    }
}