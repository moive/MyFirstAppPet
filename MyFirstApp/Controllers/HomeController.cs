using MyFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Registar a pet for adoption";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Pet pet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.Pet sdb = new DAL.Pet();
                    if (sdb.AddPet(pet))
                    {
                        ViewBag.Message = "Thanks for registering: " + pet.Name;
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                ViewBag.Message = "Pet registration error";
                return View();
            }
            
        }
    }
}