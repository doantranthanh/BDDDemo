using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Client
{
    public interface IClientHelpers
    {
        bool IsVipClient(Company company);
        bool IsImportantClient(Company company);
    }
}
