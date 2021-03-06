using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Spells
{
    public interface ISpell
    {
        bool Execute(IPlayer caster, object executor);
        int EvaluateCost();
        int ExecuteCost();
        string Debug();
    }
}
