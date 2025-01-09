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
    public class TackRoomController : Controller
    {
        // GET: TackRoom
        // CREATE
        // dit is de create pagina
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Create()
        {
            return View();
        }

        // hierin stuur je alle gegevens door en maak je een nieuwe tackroom product in de db
        [HttpPost]
        public ActionResult Create(string name, string description, decimal price, HttpPostedFileBase image, int amountInStock, string dimensions, TackRoomHangerType tackRoomHangerType)
        {
            string imageName = "unknown.jpg";
            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/TackRooms/");
                imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                path += imageName;
                image.SaveAs(path);
            }

            // bool methode die checkt als het lukt om feeder te aan te maken
            bool createSuccessful = TackRooms.Create(name, description, price, imageName, amountInStock, dimensions, tackRoomHangerType);

            if (createSuccessful)
            {
                ViewBag.Feedback = name + " werd succesvol toegevoegd!";
            }
            else
            {
                ViewBag.Feedback = "Het is niet gelukt om het product toe te voegen.";
            }

            return View();
        }

        // READ ALL
        public ActionResult Index()
        {
            List<TackRoom> lstTackRooms = TackRooms.Read();
            return View(lstTackRooms);
        }

        // READ SINGLE
        public ActionResult Details(int id)
        {
            TackRoom tr = TackRooms.Read(id);
            return View(tr);
        }

        // EDIT
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Edit(int id)
        {
            TackRoom tr = TackRooms.Read(id);
            return View(tr);
        }

        [HttpPost]
        public ActionResult Edit(int productId, string name, string description, decimal price, HttpPostedFileBase image,
            int amountInStock, string dimensions, TackRoomHangerType tackRoomHangerType)
        {
            TackRoom tr = TackRooms.Read(productId);

            string imageName = tr.Image;

            if (image != null)
            {
                imageName = (tr.Image == "unknown.jpg" ? Guid.NewGuid().ToString() : tr.Image) + Path.GetExtension(image.FileName);

                string path = Server.MapPath("~/Content/Images/TackRooms/");

                if (!string.IsNullOrEmpty(tr.Image) && tr.Image != "unknown.jpg")
                {
                    string oldPicture = Path.Combine(path, tr.Image);
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
                imageName = tr.Image;
            }

            TackRooms.Update(productId, name, description, price, imageName, amountInStock, dimensions, tackRoomHangerType);
            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult Delete(int id)
        {
            TackRoom tr = TackRooms.Read(id);
            return View(tr);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int productId)
        {
            TackRooms.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}