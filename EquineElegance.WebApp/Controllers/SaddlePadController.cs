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
    public class SaddlePadController : Controller
    {
        // GET: SaddlePad
        // CREATE
        // dit is de create pagina
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Create()
        {
            return View();
        }

        // hierin stuur je alle gegevens door en maak je een nieuwe saddlepad product in de db
        [HttpPost]
        public ActionResult Create(string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, Color color, HorseSize horseSize, SaddlePadType saddlePadType)
        {
            string imageName = "unknown.jpg";
            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/SaddlePads/");
                imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                path += imageName;
                image.SaveAs(path);
            }

            // bool methode die checkt als het lukt om saddlepad te aan te maken
            bool createSuccessful = SaddlePads.Create(name, description, price, imageName, amountInStock, color, horseSize, saddlePadType);

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
            List<SaddlePad> lstSaddlePads = SaddlePads.Read();
            return View(lstSaddlePads);
        }

        // READ SINGLE
        public ActionResult Details(int id)
        {
            SaddlePad sp = SaddlePads.Read(id);
            return View(sp);
        }

        // EDIT
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Edit(int id)
        {
            SaddlePad sp = SaddlePads.Read(id);
            return View(sp);
        }

        [HttpPost]
        public ActionResult Edit(int productId, string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, Color color, HorseSize horseSize, SaddlePadType saddlePadType)
        {
            SaddlePad sp = SaddlePads.Read(productId);

            string imageName = sp.Image;

            if (image != null)
            {
                imageName = (sp.Image == "unknown.jpg" ? Guid.NewGuid().ToString() : sp.Image) +
                            Path.GetExtension(image.FileName);

                string path = Server.MapPath("~/Content/Images/SaddlePads/");

                if (!string.IsNullOrEmpty(sp.Image) && sp.Image != "unknown.jpg")
                {
                    string oldPicture = Path.Combine(path, sp.Image);
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
                imageName = sp.Image;
            }

            SaddlePads.Update(productId, name, description, price, imageName, amountInStock, color, horseSize, saddlePadType);
            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Delete(int id)
        {
            SaddlePad sp = SaddlePads.Read(id);
            return View(sp);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int productId)
        {
            SaddlePads.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}
