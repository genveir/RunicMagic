using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;

namespace World.Magic.Effects
{
    public class DamageCaster : ISpellEffect
    {
        private readonly long _amount;

        public DamageCaster(long amount)
        {
            _amount = amount;
        }

        public void Execute(Player player)
        {
            player.ConsumeTotal(_amount);
        }
    }
}
