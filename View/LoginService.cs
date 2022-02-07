using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace View
{
    public class LoginService
    {
        private readonly PlayerFactory _playerFactory;

        public LoginService(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public async Task<PlayerService> CreatePlayerService(string name)
        {
            var player = await _playerFactory.CreatePlayer(name);

            var service = new PlayerService(player);

            WorldRunner.PlayerServices.Add(service);

            return service;
        }
    }
}
