using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.ConfigHelpers;
using App.UtilHelpers;

namespace App.Client
{
    public sealed class ClientHelpers : IClientHelpers
    {
        private readonly IConfigurationHelpers _configurationManager;

        public ClientHelpers(IConfigurationHelpers configurationManager)
        {
            ValidationUtils.ArgumentNotNull(configurationManager, nameof(configurationManager));
            _configurationManager = configurationManager;

        }

        public bool IsVipClient(Company company)
        {
            var isVipClient = string.Equals(company.Name, _configurationManager.GetValue("veryImportantClient"));
            return isVipClient;
        }

        public bool IsImportantClient(Company company)
        {
            var isImporantClient = string.Equals(company.Name, _configurationManager.GetValue("importantClient"));
            return isImporantClient;
        }
    }
}
