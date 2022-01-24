using System.Collections.Generic;
using System.Linq;
using OneOf;
using World.Creatures;
using World.Rooms;

namespace World.Magic.Runes
{
    public class ZU : Rune
    {

        public ZU(Player caster, Room room) : base(caster, room) { }

        public override OneOf<(RunePhrase, IEnumerable<Rune>), string> Parse(Player player, IEnumerable<Rune> runes)
        {
            var parseResult = SpellParser.ParseRunes(player, runes);
            if (parseResult.IsT1) return parseResult.AsT1; // error string

            var (arg, remainder) = parseResult.AsT0;
            if (!arg._rune.IsReference && !arg._rune.IsEffect)
            {
                return "target of ZU cannot resolve to an effect";
            }
            return (new RunePhrase(this, new[] { arg }), remainder);
        }

        public override EvalResult Eval(RunePhrase sn)
        {
            var arg = sn._children?.First();

            if (arg == null)
            {
                return EvalResult.Fail();
            }
            if (arg._rune.IsEffect)
            {
                return arg.Eval();
            }
            if (arg._rune.IsReference)
            {
                // TODO: for now we use BEH, which points to ITargetable.
                // other runes could refer by different means, for example:
                // ZU WATHIJDOET, referring to the spell cast by your target
                Inscription? target = null;
                this.caster.Target?.ReferenceWhenTargeted.TryPickT2(out target, out _);
                if (target == null)
                {
                    return EvalResult.Fail();
                }
                return target.InscribedSpell.Eval();
            }
            return EvalResult.Fail();
        }

        public override bool IsCastable => true;
    }
}