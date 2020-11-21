using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Domain
{
    public interface IModel
    {
        IWorld GetWorld();
        IPlayer GetPlayer();

        void ExecuteInput(IInput input);

        bool KeepRunning { get; }
        void RunTick();
    }
}
