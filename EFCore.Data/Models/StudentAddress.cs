﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data.Models
{
    public class StudentAddress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string FullAddress { get; set; }
        public string Country { get; set; }

        public virtual Student Student { get; set; }
    }
}
