using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RunicMagic.Spells
{
    public class SpellTests
    {

        [Fact]
        public void ParseZuBeh()
        {
            var spell = Parser.Parse("ZU BEH");
            Assert.NotNull(spell);
            Assert.True(spell.Debug() == "zu(beh)");
        }

        [Fact]
        public void ParseBasduTiOh()
        {
            var spell = Parser.Parse("BASDU TI OH");
            Assert.NotNull(spell);
            Assert.True(spell.Debug() == "basdu(ti(oh))");
        }

    }
}
