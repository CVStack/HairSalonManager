﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonManager.Model.Vo
{
    class ServiceVo
    {
        public ushort ServiceId { get; set; }

        public string ServiceName { get; set; }

        public uint ServicePrice { get; set; }

        public ushort ServiceTime { get; set; }

        public string ServiceDescription { get; set; }
    }
}
