using RunicMagic.Domain;
using System.Linq;
using System;

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

        public bool Execute(IPlayer caster, object executor)
        {
            // for now, we can only actually execute using Zu
            if (!root.Types.Contains("executedstatement"))
            {
                return false;
            }
            // costs for now are calculated in local scope (the room)
            var cantake = CanTake(caster.Location, caster, executor);
            var evalcost = this.EvaluateCost();
            if (evalcost > cantake) return false;
            Take(caster.Location, caster, executor, evalcost);
            cantake -= evalcost;

            var execcost = root.ExecuteCost();
            if (execcost > cantake) return false;
            Take(caster.Location, caster, executor, execcost);

            root.Execute(caster, executor);
            return true;
        }

        public int CanTake(IRoom location, IPlayer caster, object executor)
        {
            var sum = location.Items.Select(x => x as IPowerSource).Where(x => x != null).Sum(x => x.CanTake()) + 
                location.Entities.Where(x => x != caster).Sum(x => x.CanTake()) + caster.Hitpoints;
            if (executor == caster || executor as IPowerSource == null) return sum;
            return sum + (executor as IPowerSource).CanTake();
        }

        private void Take(IRoom location, IPlayer caster, object executor, int n)
        {
            if (n == 0) return;
            var executorPS = executor as IPowerSource;
            if (executorPS != null)
            {
                var fromexec = executorPS.Take(n);
                if (fromexec == n) return;
                n -= fromexec;
            }
            var fromcaster = caster.Take(n);
            if (fromcaster == n) return;
            n -= fromcaster;
            foreach(var item in location.Items)
            {
                var ps = item as IPowerSource;
                if (ps == null) return;
                var fromitem = ps.Take(n);
                if (fromitem == n) return;
                n -= fromitem;
            }
            foreach(var e in location.Entities)
            {
                var frome = e.Take(n);
                if (frome == n) return;
                n -= frome;
            }
            if (n != 0) throw new NotImplementedException("unable to take enough power; should only be called if it can");
        }
    }
}