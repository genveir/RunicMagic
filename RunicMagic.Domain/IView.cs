using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Domain
{
    public interface IView
    {
        void Display(IModel model);

        IInput GetInput();

        void DisplayOutput(string output);
    }

    public interface IInput
    {
        string ParseInput();
    }
}
