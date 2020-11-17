using RunicMagic.Domain;

namespace RunicMagic.Spells
{
    // a spell is a valid series of runes
    public class Spell : ISpell
    {
        IRune root;
        public Spell(IRune r) 
        {
            root = r;
        }

        public int EvaluateCost()
        {
            var rawcost = root.EvaluateCost();
            return rawcost / 5;
        }

        public string Debug()
        {
            return root.Debug();
        }

        public void Execute(IPlayer caster, object executor)
        {
            // for now, we can only actually execute using Zu
            if (!root.Types.Contains("executedstatement"))
            {
                return;
            }

            // TODO: evaluate costs and execute costs

            root.Execute(caster, executor);
        }
    }
}