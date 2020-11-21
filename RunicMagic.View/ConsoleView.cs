using RunicMagic.Domain;
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

            DisplayRoomName(roomToDisplay);
            DisplayRoomDescription(roomToDisplay);
            DisplayEntities(roomToDisplay);
            DisplayExits(roomToDisplay);

            DisplayPrompt();

            Console.BackgroundColor = currentBackgroundColor;
            Console.ForegroundColor = currentForegroundColor;
        }

        public void DisplayOutput(string output)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(output);
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
                    var description = entity.ShortDesc ?? (entity.Name + " is here");
                    Console.WriteLine(description);
                }
            }
        }

        private void DisplayExits(IRoom roomToDisplay)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var exitByDirection in roomToDisplay.Exits)
            {
                var door = exitByDirection.Value.Door;
                if (door != null)
                {
                    if (door.Open) Console.Write("|");
                    else Console.Write("[");
                }
                Console.Write(exitByDirection.Key);
                if (door != null)
                {
                    if (door.Open) Console.Write("|");
                    else Console.Write("]");
                }
            }
            if (roomToDisplay.Exits.Count == 0) Console.Write("none");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" ]");
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
