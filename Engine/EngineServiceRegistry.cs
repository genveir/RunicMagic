using Engine.Commands;
using Microsoft.Extensions.DependencyInjection;
using World.Plugins;

namespace Engine
{
    public static class EngineServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<PlayerFactory>();
            services.AddSingleton<CommandParser>();
        }
    }
}
