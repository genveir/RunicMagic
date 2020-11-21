using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Domain
{
    public interface IView
    {
        void Display(IModel model);

        void SetupInput(Action<IInput> inputFunc);
        void PushInput(IInput input);
        void GetInput();

        void DisplayOutput(string output);
    }

    public interface IInput
    {
        string ParseInput();
    }
}
