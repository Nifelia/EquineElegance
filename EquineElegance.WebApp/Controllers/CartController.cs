using EquineElegance.Bll;
using EquineElegance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquineElegance.WebApp.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        //methode om product aan winkelkar toe te voegen
        [HttpPost]
        public ActionResult ProductToCart(int productId, ProductType productType)
        {
            CartItem c = new CartItem()
            {
                ProductType = productType
            };


            switch (productType)
            {
                case ProductType.Blanket:
                    c.Product = Blankets.Read(productId);
                    break;
                case ProductType.Cap:
                    c.Product = Caps.Read(productId);
                    break;
                case ProductType.Feeder:
                    c.Product = Feeders.Read(productId);
                    break;
                case ProductType.RidingPant:
                    c.Product = RidingPants.Read(productId);
                    break;
                case ProductType.SaddlePad:
                    c.Product = SaddlePads.Read(productId);
                    break;
                case ProductType.TackRoom:
                    c.Product = TackRooms.Read(productId);
                    break;
            }

            // Check if product is available in stock
            if (c.Product == null || c.Product.AmountInStock <= 0)
            {
                TempData["Error"] = "Product niet meer op voorraad.";
                return RedirectToAction("Index");
            }

            // Decrease stock when adding to cart
            c.Product.AmountInStock--;
            UpdateProductStock(c.Product, c.ProductType);

            //als er nog geen winkelkar is
            if (Session["cart"] == null)
            {
                //winkelkar aanmaken
                Cart cart = new Cart();
                //lijst met cartitems aanmaken
                List<CartItem> cartItems = new List<CartItem>();
                //product aantal op 1 zetten
                c.Amount = 1;
                //product toevoegen aan lijst met items
                cartItems.Add(c);
                //lijst met items toevoegen aan kar
                cart.CartItems = cartItems;
                //winkelkar in session steken
                Session["cart"] = cart;
            }
            //als er wel al een kar aanwezig is in de session
            else
            {
                //cart object aanmaken dat alles uit de huidige session haalt
                Cart cart = (Cart)Session["cart"];

                //bool aanmaken die aanduidt of een product al in de kar zit
                bool exists = false;

                //controleren of product al in de kar zit
                foreach (var item in cart.CartItems)
                {
                    if (item.Product.ProductId == c.Product.ProductId && item.ProductType == c.ProductType)
                    {
                        exists = true;
                        //aantal van product verhogen in kar
                        item.Amount++;
                        break;
                    }
                }

                //als het product nog NIET in de kar zit
                if (!exists)
                {
                    //aantal van cartitem aanpassen, als er nog niks in zit, op 1 zetten
                    c.Amount = 1;
                    //cartitem toevoegen aan cart
                    cart.CartItems.Add(c);
                }

                Session["cart"] = cart;
            }

            return RedirectToAction("Index");
        }

        public ActionResult ClearCart()
        {
            if (Session["cart"] != null)
            {
                Cart cart = (Cart)Session["cart"];

                // Restore stock for each product in the cart
                foreach (var item in cart.CartItems)
                {
                    item.Product.AmountInStock += item.Amount;
                    UpdateProductStock(item.Product, item.ProductType);
                }

                Session.Clear();
            }

            return RedirectToAction("Index");
        }

        // Increase Quantity
        public ActionResult IncreaseQuantity(int productId, ProductType productType)
        {
            if (Session["cart"] != null)
            {
                Cart cart = (Cart)Session["cart"];
                var item = cart.CartItems.FirstOrDefault(i => i.Product.ProductId == productId && i.ProductType == productType);

                if (item != null)
                {
                    if (item.Product.AmountInStock <= 0) // Check if stock is available
                    {
                        TempData["Error"] = "Product niet meer op voorraad."; // Show error message
                    }
                    else
                    {
                        item.Amount++; // Increment the amount
                        item.Product.AmountInStock--; // Decrease the stock by 1
                        UpdateProductStock(item.Product, item.ProductType);
                    }
                }

                Session["cart"] = cart;
            }

            return RedirectToAction("Index");
        }

        // Decrease Quantity
        public ActionResult DecreaseQuantity(int productId, ProductType productType)
        {
            if (Session["cart"] != null)
            {
                Cart cart = (Cart)Session["cart"];
                var item = cart.CartItems.FirstOrDefault(i => i.Product.ProductId == productId && i.ProductType == productType);

                if (item != null)
                {
                    if (item.Amount > 1) // Ensure quantity doesn't go below 1
                    {
                        item.Amount--;
                        item.Product.AmountInStock++;  // Restore stock when the quantity is decreased
                        UpdateProductStock(item.Product, item.ProductType);
                    }
                }

                Session["cart"] = cart;
            }

            return RedirectToAction("Index");
        }

        // Remove Product
        public ActionResult RemoveProduct(int productId, ProductType productType)
        {
            if (Session["cart"] != null)
            {
                Cart cart = (Cart)Session["cart"];
                var item = cart.CartItems.FirstOrDefault(i => i.Product.ProductId == productId && i.ProductType == productType);

                if (item != null)
                {
                    item.Product.AmountInStock += item.Amount;
                    UpdateProductStock(item.Product, item.ProductType);

                    // Remove the item from the cart
                    cart.CartItems.Remove(item);
                }

                Session["cart"] = cart;
            }

            return RedirectToAction("Index");

        }

        private void UpdateProductStock(Product product, ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Blanket:
                    Blankets.Update((Blanket)product);
                    break;
                case ProductType.Cap:
                    Caps.Update((Cap)product);
                    break;
                case ProductType.Feeder:
                    Feeders.Update((Feeder)product);
                    break;
                case ProductType.RidingPant:
                    RidingPants.Update((RidingPant)product);
                    break;
                case ProductType.SaddlePad:
                    SaddlePads.Update((SaddlePad)product);
                    break;
                case ProductType.TackRoom:
                    TackRooms.Update((TackRoom)product);
                    break;
            }
        }


    }
}