using System.Collections.Generic;
using World.Creatures;
using World.Rooms;

namespace Magic
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

        public abstract (Spellnode, IEnumerable<Rune>) Parse(Player player, IEnumerable<Rune> runes);
        public abstract void Eval(Spellnode sn);

        public virtual bool IsCastable => false;
        public virtual bool IsReference => false;
        public virtual bool IsEffect => false;
    }
}