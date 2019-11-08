﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public string Name { get; set; }
        public byte DiscountRate { get; set; }
        public static readonly byte PayAs=1;
        public static readonly byte UnKnown=0;
    }
}