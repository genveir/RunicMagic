namespace Magic {
    public class Spellnode {
        private readonly Rune rune;
        private readonly Spellnode[]? children;

        public Spellnode(Rune rune) {
            this.rune = rune;
        }

        public void Eval() {
            this.rune.Eval(this);
        }
    }
}