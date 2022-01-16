using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using World.Creatures;
using OneOf;

namespace Magic
{
    public class RuneParser
    {
        private readonly Player _player;

        public RuneParser(Player player)
        {
            this._player = player;
        }

        public Spell? Parse(string runes)
        {
            var individualRunes = runes.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (individualRunes.Length == 1 && individualRunes.Single() == "DEBUG")
            {
                return new Spell();
            }
            else
            {
                return null;
            }
        }
    }
}
