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
    public class RidingPantController : Controller
    {
        // GET: Cap
        // CREATE
        // dit is de create pagina
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Create()
        {
            return View();
        }

        // hierin stuur je alle gegevens door en maak je een nieuwe ridingpant product in de db
        [HttpPost]
        public ActionResult Create(string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, Color color, Gender gender, PantsSize pantsSize)
        {
            string imageName = "unknown.jpg";
            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/RidingPants/");
                imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                path += imageName;
                image.SaveAs(path);
            }

            // bool methode die checkt als het lukt om member te aan te maken
            bool createSuccessful = RidingPants.Create(name, description, price, imageName, amountInStock, color, gender, pantsSize);

            if (createSuccessful)
            {
                ViewBag.Feedback = name + " werd succesvol toegevoegd!";
            }
            else
            {
                ViewBag.Feedback = "Het is niet gelukt om het product toe te voegen.";
            }

            // create method uit Bll gebruiken om member aan te maken
            return View();
        }

        // READ ALL
        public ActionResult Index()
        {
            List<RidingPant> lstRidingPants = RidingPants.Read();
            return View(lstRidingPants);
        }

        // READ SINGLE
        public ActionResult Details(int id)
        {
            RidingPant rp = RidingPants.Read(id);
            return View(rp);
        }

        // EDIT
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Edit(int id)
        {
            RidingPant rp = RidingPants.Read(id);
            return View(rp);
        }

        [HttpPost]
        public ActionResult Edit(int productId, string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, Color color, Gender gender, PantsSize pantsSize)
        {
            RidingPant rp = RidingPants.Read(productId);
            string imageName = rp.Image;

            if (imageName == "unknown.jpg")
            {
                rp.Image = Guid.NewGuid().ToString();
            }

            if (!Path.HasExtension(rp.Image))
            {
                imageName = rp.Image + Path.GetExtension(image.FileName);
            }

            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/RidingPants/");
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

            RidingPants.Update(productId, name, description, price, imageName, amountInStock, color, gender, pantsSize);
            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Delete(int id)
        {
            RidingPant rp = RidingPants.Read(id);
            return View(rp);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int productId)
        {
            RidingPants.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}