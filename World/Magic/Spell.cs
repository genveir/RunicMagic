using World.Creatures;

namespace World.Magic
{
    public class Spell
    {
        public Spellnode root;

        public Spell(Spellnode root)
        {
            this.root = root;
        }

        public void Cast(Player player)
        {
            if (!this.root._rune.IsCastable)
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