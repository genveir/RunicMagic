using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using World.Plugins;

namespace GoInterop
{
    public class GoInteropServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ISpellParser>(new GoApi(10000));
            services.AddSingleton<IMagicHandler>(new GoApi(10000));
        }
    }
}
