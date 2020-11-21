using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunicMagic.View
{
    public class ConsoleView : IView
    {
        private IPlayer player;

        public ConsoleView(IPlayer player)
        {
            this.player = player;
        }

        public void Display(IModel model)
        {
            var roomToDisplay = player.Location;

            var currentBackgroundColor = Console.BackgroundColor;
            var currentForegroundColor = Console.ForegroundColor;

            Console.WriteLine();
            DisplayRoomName(roomToDisplay);
            DisplayRoomDescription(roomToDisplay);
            DisplayEntities(roomToDisplay);
            DisplayExits(roomToDisplay);

            Console.BackgroundColor = currentBackgroundColor;
            Console.ForegroundColor = currentForegroundColor;

            DisplayPrompt();
        }

        public void DisplayOutput(string output)
        {
            var currentBackgroundColor = Console.BackgroundColor;
            var currentForegroundColor = Console.ForegroundColor;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(output);

            Console.BackgroundColor = currentBackgroundColor;
            Console.ForegroundColor = currentForegroundColor;

            DisplayPrompt();
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

        private Action<IInput> inputFunc;
        public void SetupInput(Action<IInput> inputFunc)
        {
            this.inputFunc = inputFunc;
        }

        public void PushInput(IInput input)
        {
            this.inputFunc(input);
        }

        // Dit even omschrijven naar ReadKey, de keys in een buffer tot je op enter duwt, en bij de prompt de buffer achter de prompt zetten
        public void GetInput()
        {
            var input = Console.ReadLine();

            PushInput(new StringInput(input));
        }
    }
}
