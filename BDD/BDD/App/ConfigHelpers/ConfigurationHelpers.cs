using System.Configuration;
using App.UtilHelpers;

namespace App.ConfigHelpers
{
    public sealed class ConfigurationHelpers : IConfigurationHelpers
    {
        public string GetValue(string key)
        {
            ValidationUtils.ArgumentNotNullOrEmpty(key, nameof(key));

            return ConfigurationManager.AppSettings[key];
        }
    }
}
