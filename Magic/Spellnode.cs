namespace Magic {
    public class Spellnode {
        internal Rune rune;
        internal Spellnode[]? children;

        public Spellnode(Rune rune) {
            this.rune = rune;
        }
        public Spellnode(Rune rune, Spellnode[] children) : this(rune)
        {
            this.children = children;
        }

        public void Eval() {
            this.rune.Eval(this);
        }
    }
}