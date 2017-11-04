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
using Timetable.WebApi.Routes;

namespace Timetable.WebApi.Controllers.v1
{
    [ApiV1RoutePrefix("buildings")]
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


        /// <summary>
        /// Returns classrooms of building
        /// </summary>
        /// <param name="id">Building id</param>
        /// <param name="page">Number of page</param>
        /// <param name="pageSize">Count of items on the page</param>
        /// <returns></returns>
        [Route("{id:int}/classrooms")]
        [ResponseType(typeof(IEnumerable<ClassroomDTO>))]
        public IHttpActionResult GetBuildingClassrooms(int id, int page = 1, int pageSize = 5)
        {
            var classroomsPaged = buildingService.GetBuildingClassrooms(id, page, pageSize);

            if(classroomsPaged.Result.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, classroomsPaged.Result);

                response.Headers.Add("X-Paging-PageNo", classroomsPaged.PageNumber.ToString());
                response.Headers.Add("X-Paging-PageSize", classroomsPaged.PageSize.ToString());
                response.Headers.Add("X-Paging-PageCount", classroomsPaged.PageCount.ToString());
                response.Headers.Add("X-Paging-TotalRecordCount", classroomsPaged.TotalRecordsCount.ToString());

                return ResponseMessage(response);
            }
        }



        

    }
}
