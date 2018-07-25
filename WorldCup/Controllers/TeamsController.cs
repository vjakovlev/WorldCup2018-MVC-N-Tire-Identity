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
    public class TeamsController : Controller
    {
        private readonly TeamServices teamServices;
        private readonly ContinentServices continentServices;

        private readonly PlayerServices playerServices;

        public TeamsController()
        {
            teamServices = new TeamServices();
            continentServices = new ContinentServices();
            playerServices = new PlayerServices();
        }

        //index
        public ActionResult Index(string searchByTeam, string searchTeam)
        {
            return View(teamServices.ReturnAllTeams(searchByTeam, searchTeam));
        }

        //create
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Continents = continentServices.ReturnAllContinents().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(TeamViewModel team)
        {
            if (ModelState.IsValid)
            {
                team.Continent = continentServices.ReturnContinent(team.ViewContinentId);
                teamServices.CreateTeam(team);
                return RedirectToAction("Index");
            }

            return View(team);
        }

        //delete
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            TeamViewModel team = teamServices.ReturnTeam(id);
            return View(team);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamViewModel team = teamServices.ReturnTeam(id); ;
            teamServices.DeleteTeam(team.Id);
            return RedirectToAction("Index");
        }

        //edit
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            TeamViewModel team = teamServices.ReturnTeam(id);
            team.ViewContinentId = team.Continent.Id;
            ViewBag.Continents = continentServices.ReturnAllContinents().ToList();
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(TeamViewModel team)
        {
            if (ModelState.IsValid)
            {
                teamServices.UpdateTeam(team);
                return RedirectToAction("Index");
            }

            return View(team);
        }

        //details
        public ActionResult Details(int id)
        {
            TeamViewModel team = teamServices.ReturnTeam(id);
            ViewBag.Players = playerServices.ReturnAllPlayers().Where(x => x.Team.Id == id);
            return View(team);
        }

    }
}

