using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class StringEffect : IEffect
    {
        private string effect;

        public StringEffect(string effect)
        {
            this.effect = effect;
        }

        public override string ToString()
        {
            return effect;
        }
    }
}
