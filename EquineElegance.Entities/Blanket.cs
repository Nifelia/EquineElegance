﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class Blanket : HorseProduct
    {
        public BlanketType BlanketType { get; set; }

        public Blanket(string name, string description, double price, string image, int amountInStock, Color color, HorseSize horseSize, 
            BlanketType blanketType) : base(name, description, price, image, amountInStock, color, horseSize)
        {
            BlanketType = blanketType;
        }

        public Blanket()
        {
            
        }
    }
}