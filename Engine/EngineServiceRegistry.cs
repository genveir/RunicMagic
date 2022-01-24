using Engine.Commands;
using Engine.Magic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Plugins;

namespace Engine
{
    public static class EngineServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<PlayerFactory>();
            services.AddSingleton<CommandParser>();
            services.AddSingleton<ISpellParser, SpellParser>();
        }
    }
}
