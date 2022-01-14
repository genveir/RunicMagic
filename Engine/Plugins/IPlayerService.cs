using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;

namespace Engine.Plugins
{
    public interface IPlayerService
    {
        Queue<string> Commands { get; }

        Player Player { get; }

        void SendOutput(string output);

        void Tick();
    }
}
