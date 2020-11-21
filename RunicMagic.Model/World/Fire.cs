using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class Fire : IItem, IPowerSource
    {
        public string Name { get; }
        
        public int PowerPoints { get; set; }

        public int CanTake()
        {
            return PowerPoints;
        }

        public int Take(int n)
        {
            if (PowerPoints > n)
            {
                PowerPoints -= n;
                return n;
            }
            // TODO: fire goes out
            var temp = PowerPoints;
            PowerPoints = 0;
            return temp;
        }

        public Fire(int points, IRoom location)
        {
            this.Name = "Fire";
            this.PowerPoints = points;
            location.Items.Add(this);
        }
    }
}
