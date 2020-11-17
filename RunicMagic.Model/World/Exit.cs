using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class Exit : IExit
    {
        public Exit(IRoom first, IRoom second)
        {
            this.LinkedRooms = (first, second);
        }

        public IDoor Door { get; set; }

        public (IRoom first, IRoom second) LinkedRooms { get; }

        public bool IsBlocked()
        {
            return Door != null && !Door.Open;
        }

        public void Transport(IMobile mobile)
        {
            var (first, second) = LinkedRooms;
            if (mobile.Location == first) mobile.Location = second;
            else if (mobile.Location == second) mobile.Location = first;
            else throw new NotImplementedException("transporting mobiles is only implemented for mobiles adjacent to the exit");
        }
    }
}
