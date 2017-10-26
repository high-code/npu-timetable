using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        [Route("")]
        public IEnumerable<BuildingDTO> GetBuildings()
        {
            var buildings = buildingService.GetAll();

            return buildings;
        }

        [Route("{id:int}")]
        public BuildingDTO GetBuilding(int id)
        {
            var building = buildingService.Get(id);

            return building;

        }


    }
}
