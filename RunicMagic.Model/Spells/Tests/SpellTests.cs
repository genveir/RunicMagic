using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RunicMagic.Spells
{
    public class SpellTests
    {

        [Fact]
        public void ParseZUBEH()
        {
            var result = Parser.Parse("ZU BEH");
            Assert.True(result.success);
            Assert.NotNull(result.spell);
            Assert.Equal("zu(beh)", result.spell.Debug());
        }

        [Fact]
        public void ParseZuBeh()
        {
            var result = Parser.Parse("zu beh");
            Assert.True(result.success);
            Assert.NotNull(result.spell);
            Assert.Equal("zu(beh)", result.spell.Debug());
        }

        [Fact]
        public void ParseBasduTiOh()
        {
            var result = Parser.Parse("BASDU TI OH");
            Assert.True(result.success);
            Assert.NotNull(result.spell);
            Assert.Equal("basdu(ti(oh,imo))", result.spell.Debug());
        }

        [Fact]
        public void ParseFail()
        {
            var result = Parser.Parse("BASDU OH TI");
            Assert.False(result.success);
            Assert.Null(result.spell);

        }

        [Fact]
        public void EvaluateCostZero()
        {
            var spell = Parser.Parse("BASDU TI OH").spell;
            Assert.NotNull(spell);
            var cost = spell.EvaluateCost();
            Assert.Equal(0, cost);
        }

        [Fact]
        public void EvaluateCostWithDefaults()
        {
            var spell = Parser.Parse("ZU BASDU TI").spell;
            Assert.NotNull(spell);
            var cost = spell.EvaluateCost();
            Assert.Equal(1, cost);
        }

        [Fact]
        public void ParsingInvalidRuneReturnsUnsuccesfulResult()
        {
            var spell = Parser.Parse("ZU SJOERD");
            Assert.False(spell.success);
        }

    }
}
