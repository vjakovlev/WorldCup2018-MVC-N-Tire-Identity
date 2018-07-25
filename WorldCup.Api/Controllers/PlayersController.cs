using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorldCup.Services;
using WorldCup.View.Model;
using System.Web.Http.Cors;

namespace WorldCup.Api.Controllers
{
    [RoutePrefix("api/Player")]
    [EnableCors(origins: "http://localhost:63741", headers: "*", methods: "*")]
    public class PlayersController : ApiController
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

        [HttpGet]
        [Route("ShowPlayers")]
        public IHttpActionResult ShowPlayers()
        {
            var data = playerServices.ReturnAllPlayers();
            return Ok(data);
        }
    }
}
