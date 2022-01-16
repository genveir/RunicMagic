namespace Magic {
	public abstract class Rune {
	    public abstract (spellnode, Rune[]) parse(Rune[] runes);
		public abstract object eval(spellnode sn);

	    public virtual bool isCastable => false; 
		public virtual bool isReference => false;
		public virtual bool isEffect => false;
	}

	public class spellnode{}
}