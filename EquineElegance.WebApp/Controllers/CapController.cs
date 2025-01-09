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
    public class CapController : Controller
    {
        // GET: Cap
        // CREATE
        // dit is de create pagina
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Create()
        {
            return View();
        }

        // hierin stuur je alle gegevens door en maak je een nieuwe cap product in de db
        [HttpPost]
        public ActionResult Create(string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, Color color, CapSize capSize)
        {
            string imageName = "unknown.jpg";
            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/Caps/");
                imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                path += imageName;
                image.SaveAs(path);
            }

            // bool methode die checkt als het lukt om member te aan te maken
            bool createSuccessful = Caps.Create(name, description, price, imageName, amountInStock, color, capSize);

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
            List<Cap> lstCaps = Caps.Read();
            return View(lstCaps);
        }

        // READ SINGLE
        public ActionResult Details(int id)
        {
            Cap cap = Caps.Read(id);
            return View(cap);
        }

        // EDIT
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Edit(int id)
        {
            Cap cap = Caps.Read(id);
            return View(cap);
        }

        [HttpPost]
        public ActionResult Edit(int productId, string name, string description, decimal price, HttpPostedFileBase image,
            int amountInStock, Color color, CapSize capSize)
        {
            Cap cap = Caps.Read(productId);

            string imageName = cap.Image;

            if (image != null)
            {
                imageName = (cap.Image == "unknown.jpg" ? Guid.NewGuid().ToString() : cap.Image) + Path.GetExtension(image.FileName);

                string path = Server.MapPath("~/Content/Images/Caps/");

                if (!string.IsNullOrEmpty(cap.Image) && cap.Image != "unknown.jpg")
                {
                    string oldPicture = Path.Combine(path, cap.Image);
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
                imageName = cap.Image;
            }

            Caps.Update(productId, name, description, price, imageName, amountInStock, color, capSize);
            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Delete(int id)
        {
            Cap cap = Caps.Read(id);
            return View(cap);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int productId)
        {
            Caps.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}