using Engine.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Peristence;
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
            services.AddSingleton<IPersistedWorld, SavedWorldState>();
        }
    }
}
