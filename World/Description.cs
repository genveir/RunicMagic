﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class Description
    {
        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string LookDesc { get; set; }

        public Description(string shortDesc, string longDesc, string lookDesc)
        {
            ShortDesc = shortDesc;
            LongDesc = longDesc;
            LookDesc = lookDesc;
        }
    }
}
