using RunicMagic.Runner;
using RunicMagic.View;
using RunicMagic.World;
using System;

namespace RunicMagic
{
    class Program
    {
        static void Main(string[] args)
        {
            new WorldBuilder().InitializeTheWorld();

            new GameRunner(new ConsoleView(), new WorldModel()).Run();
        }
    }
}
