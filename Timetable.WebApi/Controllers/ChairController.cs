using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Timetable.Service.DTO;
using Timetable.Service.Interfaces;

namespace Timetable.WebApi.Controllers
{

    [RoutePrefix("api/chairs")]
    public class ChairController : ApiController
    {

        public IChairService chairService;

        public ChairController(IChairService chairServ)
        {
            this.chairService = chairServ;
        }


        /// <summary>
        /// Returns chair by facuties or if faculty title is not specified returns all chairs
        /// </summary>
        /// <param name="facultyTitle">Title of a faculty</param>
        /// <returns>Chair</returns>
        [Route("")]
        [ResponseType(typeof(IEnumerable<ChairDTO>))]
        public IHttpActionResult GetChairs(string facultyTitle = null)
        {
            if (facultyTitle == null)
            {
                return Ok(chairService.GetAll());

            }
            else
            {
                var chairs = chairService.GetByFacultyName(facultyTitle);

                if (chairs == null)
                    return NotFound();
                else
                    return Ok(chairs);
                    
            }
        }


        /// <summary>
        /// Returns chair by its id
        /// </summary>
        /// <param name="id">Id of chair</param>
        /// <returns>Chair</returns>
        [Route("{id:int}")]
        [ResponseType(typeof(ChairDTO))]
        public IHttpActionResult GetChair(int id)
        {
            var chair = chairService.Get(id);

            if (chair == null)
                return NotFound();
            else
                return Ok(chair);
        }


    }
}
