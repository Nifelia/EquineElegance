using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EquineElegance.Bll;
using EquineElegance.Entities;
using Microsoft.Ajax.Utilities;

namespace EquineElegance.WebApp.Controllers
{
    public class CapsController : Controller
    {
        // CREATE
        // dit is de create pagina
        public ActionResult Create()
        {
            return View();
        }

        // hierin stuur je alle gegevens door en maak je een nieuwe cap product in de db
        [HttpPost]
        public ActionResult Create(string name, string description, decimal price, string image, int amountInStock, Color color, CapSize capSize)
        {
            // bool methode die checkt als het lukt om member te aan te maken
            bool createSuccessful = Caps.Create(name, description, price, image, amountInStock, color, capSize);

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
    }
}