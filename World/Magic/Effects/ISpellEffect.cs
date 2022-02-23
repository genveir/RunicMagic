using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;

namespace World.Magic.Effects
{
    public interface ISpellEffect
    {
        void Execute(Creature caster);
    }
}
