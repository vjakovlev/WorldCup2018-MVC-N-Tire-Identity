using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorldCup.Services;
using WorldCup.View.Model;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace WorldCup.Api.Controllers
{

    [RoutePrefix("api/Continent")]
    [EnableCors(origins: "http://localhost:63741", headers: "*", methods: "*")]
    public class ContinentsController : ApiController
    {
        private readonly ContinentServices continetService;

        public ContinentsController()
        {
            continetService = new ContinentServices();
        }

        [HttpGet]
        [Route("ShowContinents")]
        public IHttpActionResult ShowContinents()
        {
            var data = continetService.ReturnAllContinents();
            return Ok(data);
        }

        [HttpPost]
        [Route("Create")]
        [ResponseType(typeof(ContinentViewModel))]
        public IHttpActionResult Create(ContinentViewModel continent)
        {
            if (ModelState.IsValid)
            {
                continetService.CreateContinent(continent);
                return Ok(continent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ResponseType(typeof(ContinentViewModel))]
        public IHttpActionResult Delete(int id)
        {
            ContinentViewModel continent = continetService.ReturnContinent(id);

            if (continent == null)
            {
                return NotFound();
            }
            else
            {
                continetService.DeleteContinent(continent.Id);
                return Ok();
            } 
        }

        [HttpPut]
        [Route("Edit/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Edit(int id, ContinentViewModel continent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != continent.Id)
            {
                return BadRequest();
            }

            continetService.UpdateContinent(continent);
            return Ok(continent);

        }
    }
}

