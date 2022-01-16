namespace Magic {
    public class Spellnode {
        private Rune rune;
        private Spellnode[]? children;

        public Spellnode(Rune rune) {
            this.rune = rune;
        }

        public void eval() {
            this.rune.eval(this);
        }
    }
}