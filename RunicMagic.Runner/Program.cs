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
            var world = new CanonicalWorld();
            world.InitializeTheWorld();

            new GameRunner(new ConsoleView(world.ThePlayer), new WorldModel(world)).Run();
        }
    }
}
