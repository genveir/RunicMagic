using RunicMagic.Model.World;
using RunicMagic.Runner;
using RunicMagic.View;
using System;

namespace RunicMagic
{
    class Program
    {
        static void Main(string[] args)
        {
            new CanonicalWorld().InitializeTheWorld();

            new GameRunner(new ConsoleView(), new WorldModel()).Run();
        }
    }
}
