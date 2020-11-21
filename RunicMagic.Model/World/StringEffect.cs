using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class StringEffect : IEffect
    {
        private string effect;
        private bool shouldLook;

        public StringEffect(string effect, bool shouldLook = false)
        {
            this.effect = effect;
            this.shouldLook = shouldLook;
        }

        public bool ShouldLook => shouldLook;

        public override string ToString()
        {
            return effect;
        }
    }
}
