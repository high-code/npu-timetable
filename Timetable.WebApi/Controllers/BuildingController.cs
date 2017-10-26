using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Timetable.Service.Services;
using Timetable.Service.Interfaces;
using Timetable.Service.DTO;

namespace Timetable.WebApi.Controllers
{
    [RoutePrefix("api/buildings")]
    public class BuildingController : ApiController
    {
        IBuildingService buildingService;

        public BuildingController(IBuildingService buildingServ)
        {
            this.buildingService = buildingServ;
        }

        /// <summary>
        /// Returns buildings
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(IEnumerable<BuildingDTO>))]
        public IHttpActionResult GetBuildings()
        {
            var buildings = buildingService.GetAll();

            if (buildings == null)
                return NotFound();
            else
                return Ok(buildings);
        }

        /// <summary>
        /// Returns a building by id
        /// </summary>
        /// <param name="id">Id of building</param>
        /// <returns>Building</returns>
        [Route("{id:int}")]
        [ResponseType(typeof(BuildingDTO))]
        public IHttpActionResult GetBuilding(int id)
        {
            var building = buildingService.Get(id);

            if (building == null)
                return NotFound();
            else
                return Ok(building);

        }


    }
}
