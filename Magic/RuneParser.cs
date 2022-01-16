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

        public Spell? Parse(string spellstring)
        {
            Rune[] runes;
            try {
                runes = ReadRunes(spellstring);
            }
            catch(RuneParseException){
                return null;
            }
            if (runes.Length == 1 && runes.Single() is Runes.DEBUG)
            {
                return new Spell(new Spellnode(runes[0]));
            }
            else
            {
                return null;
            }
        }

        private Rune[] ReadRunes(string spellstring) {
            var runestrings = spellstring.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return runestrings.Select<string, Rune>(s => 
                s switch 
                {
                    "ZU" => new Runes.ZU(this._player, this._player.Location),
                    "DEBUG" => new Runes.DEBUG(this._player, this._player.Location),
                    _ => throw new RuneParseException()
                }
            ).ToArray();
        }
    }
}
