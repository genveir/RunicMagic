using RunicMagic.Domain;
using RunicMagic.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class Player : Creature, IPlayer
    {
        private static IPlayer _player;

        public static IPlayer Instance { 
            get
            {
                return _player;
            } 
        }
        private Player(string name, IRoom location) : base(name, location) { }

        public static void Initialize(string name, IRoom location)
        {
            if (_player == null) _player = new Player(name, location);
            else throw new PlayerAlreadyInitializedException("Player was already initialized");
        }

        public static void DestroyInstance()
        {
            _player = null;
        }

        public void IndicateTarget(object target)
        {
            throw new NotImplementedException();
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

            private List<ISpellEffect> _effects = new List<ISpellEffect>();
            public IEnumerable<ISpellEffect> Effects => _effects;

            public CastResult(ParseResult parseResult, string spell)
            {
                this.Success = parseResult.success;
                if (parseResult.success)
                {
                    _effects.Add(new StringSpellEffect($"You successfully cast the spell {spell}"));
                }
                else
                {
                    _effects.Add(new StringSpellEffect($"You failed to cast the spell {spell} because {parseResult.reason}"));
                }
            }
        }

        private class StringSpellEffect : ISpellEffect
        {
            private string effect;

            public StringSpellEffect(string effect)
            {
                this.effect = effect;
            }

            public override string ToString()
            {
                return effect;
            }
        }
    }
}
