using Microsoft.AspNetCore.Components.Server.Circuits;
using System.Threading;
using System.Threading.Tasks;
using View;

namespace Runic_Magic
{
    public class CircuitHandlerService : CircuitHandler
    {
        private readonly PlayerService _playerService;
        public CircuitHandlerService(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            return base.OnCircuitOpenedAsync(circuit, cancellationToken);
        }

        public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            _playerService.Dispose();
            return base.OnCircuitClosedAsync(circuit, cancellationToken);
        }
    }
}