using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult AddStylist() => View();

        [HttpPost("/stylists/create")]
        public ActionResult Create(string name, string experience, string specialty, string phone)
        {
            Stylist newStylist = new Stylist(name, experience, specialty, phone);
            newStylist.Save();
            return RedirectToAction("Index");
        }
    }
}