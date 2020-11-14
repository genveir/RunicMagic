using RunicMagic.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.View
{
    public class ConsoleView : IView
    {
        public void Display()
        {
            var roomToDisplay = Player.Instance.Location;

            Console.WriteLine(roomToDisplay.Name);
        }

        public IInput GetInput()
        {
            var input = Console.ReadLine();

            return new StringInput(input);
        }
    }
}
