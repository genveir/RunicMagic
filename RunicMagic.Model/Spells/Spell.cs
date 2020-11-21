using RunicMagic.Domain;
using System.Linq;

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

        public int ExecuteCost()
        {
            return root.ExecuteCost();
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
            // costs for now are calculated in local scope (the room)
            var cantake = CanTake(caster.Location, caster, executor);
            var evalcost = root.EvaluateCost();
            if (evalcost > cantake) return;
            Take(caster.Location, caster, executor, evalcost);
            cantake -= evalcost;

            var execcost = root.ExecuteCost();
            if (execcost > cantake) return;
            Take(caster.Location, caster, executor, execcost);

            root.Execute(caster, executor);
        }

        private int CanTake(IRoom location, IPlayer caster, object executor)
        {
            var sum = location.Items.Select(x => x as IPowerSource).Where(x => x != null).Sum(x => x.CanTake()) + 
                location.Entities.Where(x => x != caster).Sum(x => x.CanTake()) + caster.Hitpoints;
            if (executor == caster || executor as IPowerSource == null) return sum;
            return sum + (executor as IPowerSource).CanTake();
        }

        private void Take(IRoom location, IPlayer caster, object executor, int n)
        {
            foreach(var item in location.Items)
            {
                var ps = item as IPowerSource;
                if (ps == null) return;
                var actual = ps.Take(n);
                if (actual == n) return;
                n -= actual;
            }
            //foreach(var e : location.Entities)
        }
    }
}