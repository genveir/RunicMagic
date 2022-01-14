using Engine.Commands;
using Engine.Plugins;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Engine
{
    public class WorldRunner : BackgroundService
    {
        public static List<IPlayerService> PlayerServices { get; } = new List<IPlayerService>();

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Loop(cancellationToken);
        }

        public int tickSizeInMS = 100;

        private static long tick = 0;
        private async Task Loop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    tick++;
                    TimeSpan delay = TimeSpan.FromMilliseconds(tickSizeInMS);

                    var next = DateTime.Now.Add(delay);

                    DoTick();

                    delay = next - DateTime.Now;
                    if (delay < TimeSpan.Zero) delay = TimeSpan.Zero;

                    await Task.Delay(delay, cancellationToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private static void DoTick()
        {
            foreach(var playerService in PlayerServices)
            {
                if (playerService.Commands.Count > 0)
                {
                    var command = playerService.Commands.Dequeue();
                    var player = playerService.Player;
                    
                    if (!CommandParser.Parse(player, command)) player.InvalidCommand(command);
                }
            }

            foreach(var playerService in PlayerServices)
            {
                playerService.Tick();
            }
        }
    }
}