using RunicMagic.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Spells
{
    public interface ISpell
    {
        void Execute(IPlayer caster, object executor);
        string Debug();
    }
}
