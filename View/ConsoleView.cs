using RunicMagic.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.View
{
    public class ConsoleView : IView
    {
        IWorld world;
        IPlayer player;

        public void Display(IModel model)
        {
            this.world = model.GetWorld();
            this.player = model.GetPlayer();

            var roomToDisplay = player.Location;

            var currentBackgroundColor = Console.BackgroundColor;
            var currentForegroundColor = Console.ForegroundColor;

            DisplayFeedback(model);

            DisplayRoomName(roomToDisplay);
            DisplayRoomDescription(roomToDisplay);
            DisplayEntities(roomToDisplay);
            DisplayExits(roomToDisplay);

            DisplayPrompt();

            Console.BackgroundColor = currentBackgroundColor;
            Console.ForegroundColor = currentForegroundColor;
        }

        private void DisplayFeedback(IModel model)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach(var line in model.Feedback)
            {
                Console.WriteLine(line);
            }
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
                if (entity != player) 
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
            Console.Write($"{player.Hitpoints}hp)> ");
        }

        public IInput GetInput()
        {
            var input = Console.ReadLine();

            return new StringInput(input);
        }
    }
}
