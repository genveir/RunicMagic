using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.View
{
    public class StringInput : IInput
    {
        private string input;

        public StringInput(string input)
        {
            this.input = input;
        }

        public string ParseInput()
        {
            return input;
        }
    }
}
