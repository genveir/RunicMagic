using System.Collections.Generic;
using System.Linq;
using OneOf;
using SharedUtil;
using World.Creatures;
using World.Plugins;
using World.Rooms;

namespace World.Magic.Runes
{
    public class DEBUG : Rune
    {
        public DEBUG(Player caster, Room room) : base(caster, room) { }

        public override ResultOrError<(RunePhrase, IEnumerable<Rune>)> Parse(ISpellParser parser, Player player, IEnumerable<Rune> runes)
        {
            return (new RunePhrase(this), runes.Skip(1));
        }
        public override EvalResult Eval(RunePhrase sn)
        {
            var player = this.caster;

            return EvalResult.SucceedWithAction(() => player.Location.Echo($"{player.Description.ShortDesc} Debug!"));
        }

        public override bool IsEffect => true;
    }
}