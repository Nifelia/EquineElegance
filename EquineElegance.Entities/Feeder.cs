﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class Feeder : StableProduct
    {
        // Feeder (voedingsbakken/tonnen) die overerft van Product en Stableproduct waarbij je kan ingeven hoeveel er in de bak/ton kan

        [Required(ErrorMessage = "Geef de capaciteit in.")]
        public string Capacity { get; set; }

        public Feeder(string name, string description, decimal price, string image, int amountInStock, string dimensions, string capacity) : 
            base(name, description, price, image, amountInStock, dimensions)
        {
            Capacity = capacity;
            ProductType = ProductType.Feeder;
        }

        public Feeder()
        {
            
        }
    }
}
