﻿using System;

namespace PruebaAloe.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class NavigationPropertyAttribute : Attribute
    {
        public NavigationPropertyAttribute() { }
    }
}
