﻿using System;

namespace BusinessLogicLayer.Models
{
    public class AirlineBM: BaseBM
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
    }
}
