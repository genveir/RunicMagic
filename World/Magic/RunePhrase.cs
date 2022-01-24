using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Magic
{
    public class RunePhrase
    {
        internal Rune _rune;
        internal RunePhrase[]? _children;

        public RunePhrase(Rune rune)
        {
            this._rune = rune;
        }
        public RunePhrase(Rune rune, RunePhrase[] children) : this(rune)
        {
            this._children = children;
        }

        public EvalResult Eval()
        {
            return _rune.Eval(this);
        }
    }
}
