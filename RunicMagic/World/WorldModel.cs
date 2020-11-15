using RunicMagic.Domain;
using RunicMagic.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class WorldModel : IModel
    {
        public IWorld GetWorld() { return TheWorld.Instance; }
        public IPlayer GetPlayer() { return Player.Instance; }

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
                    Feedback.Add(spell.reason);
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
