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
            if (this.root._rune.type != RuneType.Castable)
            {
                player.Echo("But nothing happens!");
                return;
            }

            var result = root.Eval();

            if (!result.Success)
            {
                player.Echo("Your spell fizzles!");
            }
            else if (result.Action != null)
            {
                result.Action();
            }
            else
            {
                player.Echo("Your spell returned: {result.Value}");
            }
        }
    }
}