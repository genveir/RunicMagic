using World.Creatures;
using World.Rooms;

namespace Magic {
	public abstract class Rune {
		protected Player caster;
		protected Room room;

		public Rune(Player caster, Room room) {
			this.caster = caster;
			this.room = room;
		}

	    public abstract (Spellnode, Rune[]) parse(Rune[] runes);
		public abstract object eval(Spellnode sn);

	    public virtual bool isCastable => false; 
		public virtual bool isReference => false;
		public virtual bool isEffect => false;
	}
}