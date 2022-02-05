using System.Collections.Generic;
using System.Linq;
using OneOf;
using SharedUtil;
using World.Creatures;
using World.Plugins;
using World.Rooms;

namespace World.Magic.Runes
{
    public class BEH : Rune
    {
        public BEH(Player caster, Room room) : base(caster, room, RuneType.Reference) { }

        public override ResultOrError<(RunePhrase, IEnumerable<Rune>)> Parse(ISpellParser parser, Player player, IEnumerable<Rune> remainder)
        {
            return (new RunePhrase(this), remainder);
        }
        public override EvalResult Eval(RunePhrase sn)
        {
            var player = this.caster;
            return EvalResult.Succeed(player.Target);
        }
    }
}