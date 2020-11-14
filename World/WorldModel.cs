using RunicMagic.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class WorldModel : IModel
    {
        public bool KeepRunning { get; set; } = true;

        public void ExecuteInput(IInput input)
        {
            if (input.ParseInput() == "quit") KeepRunning = false;
        }
    }
}
