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
        public int tickSizeInMS = 100;
        private readonly CommandParser _commandParser;

        public static List<IPlayerService> PlayerServices { get; } = new List<IPlayerService>();

        public WorldRunner(CommandParser commandParser)
        {
            _commandParser = commandParser;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Loop(cancellationToken);
        }

        private async Task Loop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    TimeSpan delay = TimeSpan.FromMilliseconds(tickSizeInMS);

                    var next = DateTime.Now.Add(delay);

                    await DoTick();

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

        private async Task DoTick()
        {
            foreach (var playerService in PlayerServices)
            {
                if (playerService.Commands.Count > 0)
                {
                    var command = playerService.Commands.Dequeue();
                    var player = playerService.Player;

                    var canParse = await _commandParser.Parse(player, command);

                    if (!canParse) player.InvalidCommand(command);
                }
            }

            foreach (var playerService in PlayerServices)
            {
                playerService.Player.RegenerateHitpoints();
            }

            foreach (var playerService in PlayerServices)
            {
                await Speaking.ExecuteMagic(playerService.Player);
            }

            foreach (var playerService in PlayerServices)
            {
                playerService.Tick();
            }
        }
    }
}