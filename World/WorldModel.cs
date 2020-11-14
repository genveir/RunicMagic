using RunicMagic.Spells;
using RunicMagic.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class WorldModel : IModel
    {
        public bool KeepRunning { get; set; } = true;

        public void ExecuteInput(IInput input)
        {
            var asString = input.ParseInput();

            if (asString == "quit") KeepRunning = false;
            else if (asString.StartsWith("cast"))
            {
                var spell = Parser.Parse(asString.Substring(5));

                spell.Execute(Player.Instance, Player.Instance);
            }
        }
    }
}
