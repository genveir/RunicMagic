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
            this._root.Eval();
        }
    }
}