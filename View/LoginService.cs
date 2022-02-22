using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using World.Plugins;

namespace View
{
    public class LoginService
    {
        private readonly PlayerFactory _playerFactory;
        private readonly IMagicHandler _magicHandler;

        public LoginService(PlayerFactory playerFactory, IMagicHandler magicHandler)
        {
            _playerFactory = playerFactory;
            _magicHandler = magicHandler;
        }

        public async Task<PlayerService> CreatePlayerService(string name)
        {
            var player = await _playerFactory.CreatePlayer(name);

            var service = new PlayerService(player, _magicHandler);

            WorldRunner.PlayerServices.Add(service);

            return service;
        }
    }
}
