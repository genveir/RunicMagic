using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Engine
{
    public class Engine : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Loop(cancellationToken);
        }

        public int tickSizeInMS = 100;

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
            await Task.CompletedTask;
        }
    }
}