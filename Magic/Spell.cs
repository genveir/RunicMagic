using World.Creatures;

namespace Magic {
    public class Spell {
        public Spell(Spellnode root) {
            this.root = root;
        }
        private readonly Spellnode root;
        public void Cast() {
            this.root.Eval();
        }
    }
}