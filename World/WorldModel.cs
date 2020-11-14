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

        public ICollection<string> Feedback { get; }

        public WorldModel()
        {
            Feedback = new List<string>();
        }

        public void ExecuteInput(IInput input)
        {
            var asString = input.ParseInput();

            if (asString == "quit") KeepRunning = false;
            else if (asString.StartsWith("cast"))
            {
                var spell = Parser.Parse(asString.Substring(5));
                if (!spell.success)
                {
                    Feedback.Add("You failed to cast the spell");
                }
                else
                {
                    Feedback.Add("You succesfully cast the spell");
                    spell.spell.Execute(Player.Instance, Player.Instance);
                }
            }
        }
    }
}
