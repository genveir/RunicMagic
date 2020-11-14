using RunicMagic.World;

using System.Linq;

namespace RunicMagic.Spells
{
    // a spell is a valid series of runes
    public class Spell : ISpell
    {
        IRune root;
        public Spell(IRune r) 
        {
            root = r;
        }

        public string Debug()
        {
            return "";
        }

        public void Execute(IPlayer caster, object executor)
        {
            caster.Location.Entities.Where(e => e.Name == "Orc").Single().Hitpoints = 0;
        }
    }
}