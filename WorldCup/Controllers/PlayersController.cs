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
using PagedList;
using PagedList.Mvc;

namespace WorldCup.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayerServices playerServices;
        private readonly TeamServices teamServices;
        private readonly PositionServices positionServices;

        public PlayersController()
        {
            playerServices = new PlayerServices();
            teamServices = new TeamServices();
            positionServices = new PositionServices();
        }

        //index
        public ActionResult Index(string searchByPlayer, string searchPlayer, int? page)
        {
            return View(playerServices.ReturnAllPlayers(searchByPlayer, searchPlayer).ToPagedList(page ?? 1, 3));
        }

        //create
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Teams = teamServices.ReturnAllTeams().ToList();
            ViewBag.Positions = positionServices.ReturnAllPositions().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(PlayerViewModel player)
        {
            if (ModelState.IsValid)
            {
                player.Team = teamServices.ReturnTeam(player.ViewTeamId);
                player.Position = positionServices.ReturnPosition(player.ViewPositionId);
                playerServices.CreatePlayer(player);
                return RedirectToAction("Index");
            }

            return View(player);
        }

        //delete
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            PlayerViewModel player = playerServices.ReturnPlayer(id);
            return View(player);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerViewModel player = playerServices.ReturnPlayer(id);
            playerServices.DeletePlayer(player.Id);
            return RedirectToAction("Index");
        }

        //edit
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            PlayerViewModel player = playerServices.ReturnPlayer(id);
            player.ViewTeamId = player.Team.Id;
            ViewBag.Teams = teamServices.ReturnAllTeams().ToList();
            player.ViewPositionId = player.Position.Id;
            ViewBag.Positions = positionServices.ReturnAllPositions().ToList();
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(PlayerViewModel player)
        {
            if (ModelState.IsValid)
            {
                playerServices.UpdatePlayer(player);
                return RedirectToAction("Index");
            }

            return View(player);
        }

        //details
        public ActionResult Details(int id)
        {
            PlayerViewModel player = playerServices.ReturnPlayer(id);
            return View(player);
        }

    }
}
