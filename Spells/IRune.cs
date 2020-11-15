using System;
using System.Collections.Generic;

namespace RunicMagic.Spells
{
    public interface IRune
    {
        string Name { get; }
        List<string> Types {get;}
        bool Parse(Stack<IRune> stack);
        int EvaluateCost();
        string Debug();
    }

}
