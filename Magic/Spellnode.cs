namespace Magic
{
    public class Spellnode
    {
        internal Rune _rune;
        internal Spellnode[]? _children;

        public Spellnode(Rune rune)
        {
            this._rune = rune;
        }
        public Spellnode(Rune rune, Spellnode[] children) : this(rune)
        {
            this._children = children;
        }

        public EvalResult Eval()
        {
            return _rune.Eval(this);
        }
    }
}