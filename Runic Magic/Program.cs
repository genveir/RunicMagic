using Engine;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Runic_Magic.View;

namespace Runic_Magic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            RegisterServices(builder.Services);

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddHostedService<WorldRunner>();

            EngineServiceRegistry.RegisterServices(services);
            PersistenceServiceRegistry.RegisterServices(services);

            services.AddScoped<PlayerService>();
        }
    }
}