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
            Feedback.Clear();

            var asString = input.ParseInput();

            if (asString == "quit") KeepRunning = false;
            else if (asString.StartsWith("cast"))
            {
                var result = Player.Instance.Cast(asString.Substring(5));

                foreach(var effect in result.Effects)
                {
                    Feedback.Add(effect.ToString());
                }
            }
        }
    }
}
