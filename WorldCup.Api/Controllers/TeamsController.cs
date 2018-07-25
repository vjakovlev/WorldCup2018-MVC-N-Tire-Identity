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
    [RoutePrefix("api/Team")]
    [EnableCors(origins: "http://localhost:63741", headers: "*", methods: "*")]
    public class TeamsController : ApiController
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

        [HttpGet]
        [Route("ShowTeams")]
        public IHttpActionResult ShowTeams()
        {
            var data = teamServices.ReturnAllTeams();
            return Ok(data);
        }
    }
}
