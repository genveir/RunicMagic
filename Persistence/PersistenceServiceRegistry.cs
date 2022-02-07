using Engine.Plugins;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IPersistedWorld>(svc => new SavedWorldState(svc.GetRequiredService<IRunicMagicContextProvider>()));
            services.AddSingleton<IRunicMagicContextProvider>(
                svc => new RunicMagicContextProvider(svc.GetRequiredService<IConfiguration>().GetConnectionString("runicMagicDb")));
        }
    }
}
