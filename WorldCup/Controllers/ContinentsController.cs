using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldCup.View.Model;
using WorldCup.Services;

namespace WorldCup.Controllers
{
    [Authorize]
    public class ContinentsController : Controller
    {
        private readonly ContinentServices continentServices;

        public ContinentsController()
        {
            continentServices = new ContinentServices();
        }

        //index
        public ActionResult Index()
        {
            return View(continentServices.ReturnAllContinents());
        }
    }
}
