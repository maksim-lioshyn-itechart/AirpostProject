﻿using System;

namespace DataAccessLayer.Models
{
    public class Airport : BaseModel
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
