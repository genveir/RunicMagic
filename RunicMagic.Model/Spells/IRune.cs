using System.Collections.Generic;
using RunicMagic.Domain;

namespace RunicMagic.Spells
{
    public interface IRune
    {
        string Name { get; }
        HashSet<string> Types {get;}
        bool Parse(Stack<IRune> stack);
        int EvaluateCost();
        int ExecuteCost();
        string Debug();
        void Execute(IPlayer player, object executor);
    }

}
