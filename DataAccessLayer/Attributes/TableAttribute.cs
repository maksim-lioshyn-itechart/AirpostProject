﻿using System;

namespace DataAccessLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute: Attribute
    {
        public string Name { get; set; }
    }
}
