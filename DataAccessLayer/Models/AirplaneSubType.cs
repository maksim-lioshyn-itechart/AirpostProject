﻿using System;

namespace DataAccessLayer.Models
{
    public class AirplaneSubType: BasicModel
    {
        public string Name { get; set; }
        public Guid AirplaneTypeId { get; set; }
    }
}