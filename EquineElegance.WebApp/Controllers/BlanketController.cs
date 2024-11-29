using EquineElegance.Bll;
using EquineElegance.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquineElegance.WebApp.Controllers
{
    public class BlanketController : Controller
    {
        // GET: Blanket
        // CREATE
        // dit is de create pagina
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Create()
        {
            return View();
        }

        // hierin stuur je alle gegevens door en maak je een nieuwe blanket product in de db
        [HttpPost]
        public ActionResult Create(string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, Color color, HorseSize horseSize, BlanketType blanketType)
        {
            string imageName = "unknown.jpg";
            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/Blankets/");
                imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                path += imageName;
                image.SaveAs(path);
            }

            // bool methode die checkt als het lukt om member te aan te maken
            bool createSuccessful = Blankets.Create(name, description, price, imageName, amountInStock, color, horseSize, blanketType);

            if (createSuccessful)
            {
                ViewBag.Feedback = name + " werd succesvol toegevoegd!";
            }
            else
            {
                ViewBag.Feedback = "Het is niet gelukt om het product toe te voegen.";
            }

            // create method uit Bll gebruiken om blanket aan te maken
            return View();
        }

        // READ ALL
        public ActionResult Index()
        {
            List<Blanket> lstBlankets = Blankets.Read();
            return View(lstBlankets);
        }

        // READ SINGLE
        public ActionResult Details(int id)
        {
            Blanket b = Blankets.Read(id);
            return View(b);
        }

        // EDIT
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Edit(int id)
        {
            Blanket b = Blankets.Read(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(int productId, string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, Color color, HorseSize horseSize, BlanketType blanketType)
        {
            Blanket b = Blankets.Read(productId);
            string imageName = b.Image;

            if (imageName == "unknown.jpg")
            {
                b.Image = Guid.NewGuid().ToString();
            }

            if (!Path.HasExtension(b.Image))
            {
                imageName = b.Image + Path.GetExtension(image.FileName);
            }

            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/Blankets/");
                if (!string.IsNullOrEmpty(imageName))
                {
                    string oldPicture = Path.Combine(path, imageName);
                    if (System.IO.File.Exists(oldPicture))
                    {
                        System.IO.File.Delete(oldPicture);
                    }
                }
                string newPicture = Path.Combine(path, imageName);
                image.SaveAs(newPicture);

            }

            Blankets.Update(productId, name, description, price, imageName, amountInStock, color, horseSize, blanketType);
            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Delete(int id)
        {
            Blanket b = Blankets.Read(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int productId)
        {
            Blankets.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}