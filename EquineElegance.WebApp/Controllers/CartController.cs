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
                //bool aanmaken die aanduidt of een product al in de kar zit
                bool exists = false;

                //cart object aanmaken dat alles uit de huidige session haalt
                Cart cart = (Cart)Session["cart"];

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
                    //aantal van cartitem op 1 zetten
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
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}