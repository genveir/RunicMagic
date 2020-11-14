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

            var currentBackgroundColor = Console.BackgroundColor;
            var currentForegroundColor = Console.ForegroundColor;

            DisplayRoomName(roomToDisplay);
            DisplayRoomDescription(roomToDisplay);
            DisplayEntities(roomToDisplay);
            DisplayExits(roomToDisplay);

            DisplayPrompt();

            Console.BackgroundColor = currentBackgroundColor;
            Console.ForegroundColor = currentForegroundColor;
        }

        private void DisplayRoomName(IRoom roomToDisplay)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(roomToDisplay.Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("]");
        }

        private void DisplayRoomDescription(IRoom roomToDisplay)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(roomToDisplay.Description);
        }

        private void DisplayEntities(IRoom roomToDisplay) 
        { 
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var entity in roomToDisplay.Entities)
            {
                if (entity != Player.Instance) 
                {
                    Console.WriteLine($"{entity.ShortDesc ?? entity.Name} is here.");
                }
            }
        }

        private void DisplayExits(IRoom roomToDisplay)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("There are no exits..");
        }

        private void DisplayPrompt()
        {
            Console.Write($"{Player.Instance.Hitpoints}hp)> ");
        }

        public IInput GetInput()
        {
            var input = Console.ReadLine();

            return new StringInput(input);
        }
    }
}
