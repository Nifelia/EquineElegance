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
        [Required(ErrorMessage = "Productnaam mag niet leeg zijn.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lengte moet tussen {2} en {1}.")]
        [RegularExpression(@"^(?=.*\S).+$", ErrorMessage = "Productnaam mag geen lege spaties zijn.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Beschrijving mag niet leeg zijn.")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Lengte moet tussen {2} en {1}.")]
        [RegularExpression(@"^(?=.*\S).+$", ErrorMessage = "Productnaam mag geen lege spaties zijn.")]
        public string Description { get; set; }
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Prijs moet hoger zijn dan 0.")]
        [RegularExpression(@"\d+([.,]\d{2})?", ErrorMessage = "Prijs moet twee decimalen hebben.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Gelieve een afbeelding toe te voegen.")]
        // onderstaande validatie code ga ik activeren wanneer image niet meer een tekst input vakje zal zijn
        // [RegularExpression(@"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)", ErrorMessage = "Ongeldige afbeeldings-URL.")]
        public string Image { get; set; }
        [Range(0, 1000, ErrorMessage = "Voorraad moet 0 of hoger zijn.")]
        public int AmountInStock { get; set; }

        public ProductType ProductType { get; set; }

        public Product(string name, string description, decimal price, string image, int amountInStock)
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
