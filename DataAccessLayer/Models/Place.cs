﻿using DataAccessLayer.Enums;

namespace DataAccessLayer.Models
{
    public class Place: BasicModel
    {
        public PlaceType Type { get; set; }
        public int CoordinateX1 { get; set; }
        public int CoordinateX2 { get; set; }
        public int CoordinateY1 { get; set; }
        public int CoordinateY2 { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
    }
}
