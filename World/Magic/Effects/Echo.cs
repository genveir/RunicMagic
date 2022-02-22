using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;

namespace World.Magic.Effects
{
    public class Echo : ISpellEffect
    {
        private readonly string _text;

        public Echo(string text)
        {
            _text = text;
        }

        public void Execute(Player player)
        {
            player.Location.Echo(_text);
        }
    }
}
