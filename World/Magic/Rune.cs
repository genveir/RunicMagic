using System.Collections.Generic;
using OneOf;
using World.Creatures;
using World.Rooms;

namespace World.Magic
{
    public abstract class Rune
    {
        protected Player caster;
        protected Room room;

        protected Rune(Player caster, Room room)
        {
            this.caster = caster;
            this.room = room;
        }

        public abstract OneOf<(RunePhrase, IEnumerable<Rune>), string> Parse(Player player, IEnumerable<Rune> runes);
        public abstract EvalResult Eval(RunePhrase sn);

        public virtual bool IsCastable => false;
        public virtual bool IsReference => false;
        public virtual bool IsEffect => false;
    }
}