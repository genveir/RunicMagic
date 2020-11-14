using RunicMagic.World;

using System.Linq;

namespace RunicMagic.Spells
{
    public class Spell : ISpell
    {
        public Spell() 
        {

        }

        public void Execute(IPlayer caster, object executor)
        {
            TheWorld.Instance.GetTheOnlyRoom().Entities.Where(e => e.Name == "Orc").Single().Hitpoints = 0;
        }
    }
}