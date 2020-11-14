using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.View
{
    public interface IView
    {
        void Display();

        IInput GetInput();
    }

    public interface IInput
    {
        string ParseInput();
    }
}
