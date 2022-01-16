using World.Creatures;

namespace Magic
{
    public class Spell
    {
        private readonly Spellnode _root;

        public Spell(Spellnode root)
        {
            this._root = root;
        }

        public void Cast(Player player)
        {
            if (!this._root._rune.IsCastable)
            {
                player.Echo("But nothing happens!");
                return;
            }

            var result = _root.Eval();

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