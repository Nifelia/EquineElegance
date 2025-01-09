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
    public class FeederController : Controller
    {
        // GET: Feeder
        // CREATE
        // dit is de create pagina
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Create()
        {
            return View();
        }

        // hierin stuur je alle gegevens door en maak je een nieuwe feeder product in de db
        [HttpPost]
        public ActionResult Create(string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, string dimensions, string capacity)
        {
            string imageName = "unknown.jpg";
            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/Feeders/");
                imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                path += imageName;
                image.SaveAs(path);
            }

            // bool methode die checkt als het lukt om feeder te aan te maken
            bool createSuccessful = Feeders.Create(name, description, price, imageName, amountInStock, dimensions, capacity);

            if (createSuccessful)
            {
                ViewBag.Feedback = name + " werd succesvol toegevoegd!";
            }
            else
            {
                ViewBag.Feedback = "Het is niet gelukt om het product toe te voegen.";
            }

            // create method uit Bll gebruiken om feeder aan te maken
            return View();
        }

        // READ ALL
        public ActionResult Index()
        {
            List<Feeder> lstFeeders = Feeders.Read();
            return View(lstFeeders);
        }

        // READ SINGLE
        public ActionResult Details(int id)
        {
            Feeder f = Feeders.Read(id);
            return View(f);
        }

        // EDIT
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Edit(int id)
        {
            Feeder f = Feeders.Read(id);
            return View(f);
        }

        [HttpPost]
        public ActionResult Edit(int productId, string name, string description, decimal price, HttpPostedFileBase image,
            int amountInStock, string dimensions, string capacity)
        {
            Feeder f = Feeders.Read(productId);

            string imageName = f.Image;

            if (image != null)
            {
                imageName = (f.Image == "unknown.jpg" ? Guid.NewGuid().ToString() : f.Image) + Path.GetExtension(image.FileName);

                string path = Server.MapPath("~/Content/Images/Feeders/");

                if (!string.IsNullOrEmpty(f.Image) && f.Image != "unknown.jpg")
                {
                    string oldPicture = Path.Combine(path, f.Image);
                    if (System.IO.File.Exists(oldPicture))
                    {
                        System.IO.File.Delete(oldPicture);
                    }
                }

                string newPicture = Path.Combine(path, imageName);
                image.SaveAs(newPicture);
            }
            else
            {
                imageName = f.Image;
            }

            Feeders.Update(productId, name, description, price, imageName, amountInStock, dimensions, capacity);
            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Delete(int id)
        {
            Feeder f = Feeders.Read(id);
            return View(f);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int productId)
        {
            Feeders.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}