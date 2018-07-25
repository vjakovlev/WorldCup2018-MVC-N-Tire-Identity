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
    public class MatchesController : Controller
    {
        private readonly MatchServices matchServices;
        private readonly TeamServices teamServices;

        public MatchesController()
        {
            matchServices = new MatchServices();
            teamServices = new TeamServices();
        }

        //index
        public ActionResult Index(string searchByMatch, string searchMatch)
        {
            return View(matchServices.ReturnAllMatches(searchByMatch, searchMatch));
        }

        //create
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.A = teamServices.ReturnAllTeams().ToList();
            ViewBag.B = teamServices.ReturnAllTeams().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(MatchViewModel match)
        {
            if (ModelState.IsValid)
            {
                match.TeamA = teamServices.ReturnTeam(match.ViewTeamAId);
                match.TeamB = teamServices.ReturnTeam(match.ViewTeamBId);
                matchServices.CreateMatch(match);
                return RedirectToAction("Index");
            }

            return View(match);
        }

        //delete
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            MatchViewModel match = matchServices.ReturnMatch(id);
            return View(match);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchViewModel match = matchServices.ReturnMatch(id);
            matchServices.DeleteMatch(match.Id);
            return RedirectToAction("Index");
        }

        //edit
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            MatchViewModel match = matchServices.ReturnMatch(id);
            match.ViewTeamAId = match.TeamA.Id;
            ViewBag.A = teamServices.ReturnAllTeams().ToList();
            match.ViewTeamBId = match.TeamB.Id;
            ViewBag.B = teamServices.ReturnAllTeams().ToList();
            return View(match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(MatchViewModel match)
        {
            if (ModelState.IsValid)
            {
                matchServices.UpdateMatch(match);
                return RedirectToAction("Index");
            }

            return View(match);
        }

        //details
        public ActionResult Details(int id)
        {
            MatchViewModel match = matchServices.ReturnMatch(id);
            return View(match);
        }

        //statistics
        public ActionResult Statistics()
        {
            decimal? averageGoalPerTeam = matchServices.AverageGoalPerTeam();
            decimal? averageGoalsPerMatch = matchServices.AverageGoalsPerMatch();

            ViewData["total"] = matchServices.TotalGoals();
            ViewData["totalMatches"] = matchServices.TotalMatchesPlyed();
            ViewData["averagePerTeam"] = Math.Round((decimal)averageGoalPerTeam, 2);
            ViewData["averagePerMatch"] = Math.Round((decimal)averageGoalsPerMatch, 2);

            return View();
        }

    }
}
