﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services;
using VirtoCommerce.Foundation.Marketing.Factories;
using VirtoCommerce.Foundation.Data.Infrastructure;

namespace VirtoCommerce.Foundation.Data.Marketing
{
    [JsonSupportBehavior]
	public class DSMarketingService : DServiceBase<EFMarketingRepository>
	{
	}
}
