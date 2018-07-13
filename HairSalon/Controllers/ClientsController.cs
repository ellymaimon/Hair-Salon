using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpGet("/clients/new")]
        public ActionResult AddClient() => View();

        [HttpPost("/clients/create")]
        public ActionResult Create(string name, string gender, int stylistId)
        {
            Client newClient = new Client(name, gender, 0, stylistId);
            newClient.Save();
            return RedirectToAction("Index");
        }
    }
}