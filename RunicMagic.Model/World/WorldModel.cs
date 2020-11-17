using RunicMagic.Domain;
using RunicMagic.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
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
            else
            {
                IEnumerable<IEffect> MoveEffect;
                switch(asString)
                {
                    case "n": MoveEffect = Player.Instance.Move(Direction.North); break;
                    case "e": MoveEffect = Player.Instance.Move(Direction.East); break;
                    case "s": MoveEffect = Player.Instance.Move(Direction.South); break;
                    case "w": MoveEffect = Player.Instance.Move(Direction.West); break;
                    case "u": MoveEffect = Player.Instance.Move(Direction.Up); break;
                    case "d": MoveEffect = Player.Instance.Move(Direction.Down); break;
                    default: MoveEffect = new List<IEffect>(); break;
                }

                foreach (var effect in MoveEffect)
                {
                    Feedback.Add(effect.ToString());
                }
            }
        }
    }
}
