﻿using System.Linq;
using VirtoCommerce.Foundation.Data.AppConfig;
using VirtoCommerce.Foundation.Data.AppConfig.Migrations;
using VirtoCommerce.PowerShell.DatabaseSetup;

namespace VirtoCommerce.PowerShell.AppConfig
{
	public class SqlAppConfigDatabaseInitializer : SetupDatabaseInitializer<EFAppConfigRepository, Configuration>
	{
		public string Scope { private get; set; }

        readonly string[] _files =
	    { 
	        "Setting.sql",
			"SettingValue.sql",
			"SystemJob.sql",
			"JobParameter.sql",
			"EmailTemplate.sql",
			"EmailTemplateLanguage.sql",
			"Localization.sql"
	    };

        protected virtual string[] GetSampleFiles()
        {
            return _files;
        }

		protected override void Seed(EFAppConfigRepository context)
		{
			base.Seed(context);
			FillAppConfigScripts(context);
			UpdateScopeParameterValue(context);
		}

		private void FillAppConfigScripts(EFAppConfigRepository context)
		{
            foreach (var file in GetSampleFiles())
            {
                RunCommand(context, file, "AppConfig");
            }
		}

		private void UpdateScopeParameterValue(EFAppConfigRepository context)
		{
			if (!string.IsNullOrEmpty(Scope))
			{
				var scopeParameters = context.SystemJobs.Where(x => x.JobParameters.Any(p => p.Name == "scope"))
											 .SelectMany(x => x.JobParameters)
											 .Where(x => x.Name == "scope")
											 .ToList();
				scopeParameters.ForEach(x => x.Value = Scope);
				context.SaveChanges();
			}
		}
	}
}