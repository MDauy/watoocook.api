﻿using ValueOf;

namespace Watoocook.Domain.Models
{
    public class Quantity : ValueOf<string, Quantity>
    {
        public Quantity()
        {

        }
        public Quantity(string val)
        {
            this.Value = val;
        }
    }
}
