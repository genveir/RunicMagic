using World.Creatures;

namespace Magic {
    public class Spell {
        public Spell(Spellnode root) {
            this.root = root;
        }
        private Spellnode root;
        public void cast(Player player) {
            this.root.eval();
        }
    }
}