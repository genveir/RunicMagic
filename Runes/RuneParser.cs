using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using World.Creatures;

namespace Runes
{
    public class RuneParser
    {
        private readonly Player _player;

        public RuneParser(Player player)
        {
            this._player = player;
        }

        public void Parse(string runes)
        {
            var individualRunes = runes.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (individualRunes.Length == 1 && individualRunes.Single() == "DEBUG")
            {
                _player.Location.Echo($"{_player.ShortDesc} Debug!");
            }
            else
            {
                _player.Echo("Your spell fizzles!");
            }
        }
    }
}
