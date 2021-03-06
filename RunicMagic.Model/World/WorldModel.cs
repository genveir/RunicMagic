using RunicMagic.Domain;
using RunicMagic.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class WorldModel : IModel
    {
        private IWorld world;

        public IWorld GetWorld() { return world; }
        public IPlayer GetPlayer() { return world.ThePlayer; }

        public bool KeepRunning { get; set; } = true;

        public WorldModel(IWorld world)
        {
            this.world = world;
        }

        public void RunTick()
        {
            
        }

        public void ExecuteInput(IInput input)
        {
            var asString = input.ParseInput();

            if (asString == "quit") KeepRunning = false;
            else if (asString.StartsWith("indicate"))
            {
                var targetStr = asString.Substring(9);
                var target = world.ThePlayer.Location.GetTarget(targetStr);
                if (target == null) GetPlayer().PushOutput(new StringEffect("invalid target"));
                else GetPlayer().IndicateTarget(target);
            }
            else if (asString.StartsWith("cast"))
            {
                var result = GetPlayer().Cast(asString.Substring(5));

                foreach(var effect in result.Effects)
                {
                    GetPlayer().PushOutput(effect);
                }
            }
            else
            {
                IEnumerable<IEffect> MoveEffect;
                switch(asString)
                {
                    case "n": MoveEffect = world.ThePlayer.Move(Direction.North); break;
                    case "e": MoveEffect = world.ThePlayer.Move(Direction.East); break;
                    case "s": MoveEffect = world.ThePlayer.Move(Direction.South); break;
                    case "w": MoveEffect = world.ThePlayer.Move(Direction.West); break;
                    case "u": MoveEffect = world.ThePlayer.Move(Direction.Up); break;
                    case "d": MoveEffect = world.ThePlayer.Move(Direction.Down); break;
                    default: MoveEffect = new List<IEffect>(); break;
                }

                foreach (var effect in MoveEffect)
                {
                    GetPlayer().PushOutput(effect);
                }
            }
            if (GetPlayer().Hitpoints == 0)
            {
                GetPlayer().PushOutput(new StringEffect("You died"));
                KeepRunning = false;
            }
        }
    }
}
