namespace Magic.Runes {
    public class ZU : Rune {
       public override (spellnode, Rune[]) parse(Rune[] runes) {
           return (null, null);
       }
	    public override object eval(spellnode sn) {
           return null;
       }

       public override bool isCastable => true;
    }
}