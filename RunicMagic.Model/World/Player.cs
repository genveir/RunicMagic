using RunicMagic.Domain;
using RunicMagic.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class Player : Mobile, IPlayer
    {
        public Player(string name, IRoom location) : base(name, location) { }

        public object IndicatedTarget { get; private set; }

        public void IndicateTarget(object target)
        {
            IndicatedTarget = target;
        }

        public ICastResult Cast(string spell)
        {
            var parseResult = Parser.Parse(spell);

            if (parseResult.success)
            {
                parseResult.spell.Execute(this, this);
            }
            var castResult = new CastResult(parseResult, spell);

            return castResult;
        }

        public string Look()
        {
            throw new NotImplementedException();
        }

        private class CastResult : ICastResult
        {
            public bool Success { get; set; }

            private List<IEffect> _effects = new List<IEffect>();
            public IEnumerable<IEffect> Effects => _effects;

            public CastResult(ParseResult parseResult, string spell)
            {
                this.Success = parseResult.success;
                if (parseResult.success)
                {
                    _effects.Add(new StringEffect($"You successfully cast the spell {spell}"));
                }
                else
                {
                    _effects.Add(new StringEffect($"You failed to cast the spell {spell} because {parseResult.reason}"));
                }
            }
        }
    }
}
