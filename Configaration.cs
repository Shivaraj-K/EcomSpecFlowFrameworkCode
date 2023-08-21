using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceTesting.Pages
{
    public class Configaration
    {
        public void ConfigureServices(IServiceCollection s)
        {
            s.AddScoped<ICommon, CommonClass>();
        }
    }
}
