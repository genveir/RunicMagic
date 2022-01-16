using World.Creatures;

namespace Magic {
    public class Spell {
        public Spell(Spellnode root) {
            this.root = root;
        }
        private readonly Spellnode root;
        public void Cast(Player player) {
            if (!this.root.rune.IsCastable)
            {
                player.Echo("But nothing happens!");
                return;
            }
            this.root.Eval();
        }
    }
}