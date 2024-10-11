using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class Product
    {
        // hierbij zijn properties aangemaakt die bij ieder product terug zullen komen

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int AmountInStock { get; set; }

        public Product(string name, string description, double price, string image, int amountInStock)
        {
            Name = name;
            Description = description;
            Price = price;
            Image = image;
            AmountInStock = amountInStock;
        }

        public Product()
        {
            
        }
    }
}
