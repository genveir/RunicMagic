using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class Mobile : IMobile
    {
        public string Name { get; }

        public string ShortDesc { get; set; }

        public IRoom Location { get; set; }

        public int Hitpoints { get; set; }

        public int CanTake()
        {
            return Hitpoints;
        }

        public int Take(int n)
        {
            if (Hitpoints > n)
            {
                Hitpoints -= n;
                return n;
            }
            // TODO: creature dies
            var temp = Hitpoints;
            Hitpoints = 0;
            return temp;
        }

        public IEnumerable<IEffect> Move(Direction direction)
        {
            var effects = new List<IEffect>();

            IExit exit;
            Location.Exits.TryGetValue(direction, out exit);
            if (exit == null)
            {
                effects.Add(new StringEffect("donk! You walk into the wall!"));
            }
            else
            {
                if (exit.IsBlocked())
                {
                    effects.Add(new StringEffect("bonk! The way is blocked!"));
                }
                else
                {
                    effects.Add(new StringEffect("You walk " + direction.ToString()));

                    exit.Transport(this);
                }
            }

            return effects;
        }

        public Mobile(string name, IRoom location)
        {
            this.Name = name;
            this.Location = location;

            location.Entities.Add(this);
        }
    }
}
