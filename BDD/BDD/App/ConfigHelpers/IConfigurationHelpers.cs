using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.ConfigHelpers
{
    public interface IConfigurationHelpers
    {
        string GetValue(string key);
    }
}
