﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class TackRoom : StableProduct
    {
        // TackRoom (zadelkamer) class die overerft van Product en StableProduct waarin je de hanger type kan kiezen

        public TackRoomHangerType TackRoomHangerType { get; set; }

        public TackRoom(string name, string description, double price, string image, int amountInStock, string dimensions, TackRoomHangerType tackRoomHangerType) :
            base(name, description, price, image, amountInStock, dimensions)
        {
            TackRoomHangerType = tackRoomHangerType;
        }

        public TackRoom()
        {
            
        }
    }
}
