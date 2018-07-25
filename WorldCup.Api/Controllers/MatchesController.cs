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
    [RoutePrefix("api/Match")]
    [EnableCors(origins: "http://localhost:63741", headers: "*", methods: "*")]
    public class MatchesController : ApiController
    {
        private readonly MatchServices matchServices;
        private readonly TeamServices teamServices;

        public MatchesController()
        {
            matchServices = new MatchServices();
            teamServices = new TeamServices();
        }

        [HttpGet]
        [Route("ShowMatches")]
        public IHttpActionResult ShowMatches()
        {
            var data = matchServices.ReturnAllMatches();
            return Ok(data);
        }

        [HttpGet]
        [Route("Statistics")]
        public IHttpActionResult Statistics()
        {
            decimal? averageGoalPerTeam = matchServices.AverageGoalPerTeam();
            decimal? averageGoalsPerMatch = matchServices.AverageGoalsPerMatch();

            var wcStatistics = new
            {
                totalGoals = matchServices.TotalGoals(),
                totalMatches = matchServices.TotalMatchesPlyed(),
                averageGoalPerTeam = Math.Round((decimal)averageGoalPerTeam, 2),
                averageGoalsPerMatch = Math.Round((decimal)averageGoalsPerMatch, 2)
            };

            return Ok(wcStatistics);
        }

    }
}
