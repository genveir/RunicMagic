using World.Creatures;
using World.Rooms;

namespace Magic {
	public abstract class Rune {
		protected Player caster;
		protected Room room;

		protected Rune(Player caster, Room room) {
			this.caster = caster;
			this.room = room;
		}

	    public abstract (Spellnode, Rune[]) Parse(Rune[] runes);
		public abstract object Eval(Spellnode sn);

	    public virtual bool IsCastable => false;
		public virtual bool IsReference => false;
		public virtual bool IsEffect => false;
	}
}