﻿using System;

namespace DataAccessLayer.Models
{
    public class AirplaneSubType: BasicModel
    {
        public Guid AirplaneTypeId { get; set; }
        public string Name { get; set; }
    }
}
