using World.Creatures;

namespace World.Magic
{
    public class Spell
    {
        public RunePhrase root;

        public Spell(RunePhrase root)
        {
            this.root = root;
        }

        public void GetSpoken(Player player)
        {
            if (this.root._rune.ResultType() != RuneType.Castable)
            {
                player.Echo("But nothing happens!");
                return;
            }

            var result = root.Eval();

            if (!result.Success)
            {
                player.Echo("Your spell fizzles!");
                return;
            }
            if (result.Action == null)
            {
                player.Echo("Your spell returned: {result.Value}");
                return;
            }
            // assumption: only have cost when have an action
            var resources = result.PossibleSources(player);
            var completelyConsumed = this.consume(result.Cost, resources);
            if (!completelyConsumed)
            {
                player.Echo("Your spell fizzles!");
                return;
            }
            result.Action();
        }

        public bool consume(long cost, IPowerSource[] resources)
        {
            foreach (IPowerSource ps in resources)
            {
                var actualConsumption = ps.consumeTotal(cost);
                cost -= actualConsumption;
                if (cost == 0)
                {
                    break;
                }
            }
            return (cost==0);
        }
    }
}