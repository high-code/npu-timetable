using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Timetable.Service.DTO;
using Timetable.Service.Interfaces;
using Timetable.WebApi.Routes;

namespace Timetable.WebApi.Controllers.v1
{

    
    [ApiV1RoutePrefix("consults")]
    public class ConsultController : ApiController
    {
        IConsultsService consultsService;

        public ConsultController(IConsultsService consultsServ)
        {
            consultsService = consultsServ;
        }


        /// <summary>
        /// Method to get consults
        /// </summary>
        /// <param name="date">Consult date</param>
        /// <param name="facultyTitle">Title of faculty</param>
        /// <param name="subjectName">Name of subject</param>
        /// <param name="classroomTitle">Title of classroom</param>
        /// <param name="academicGroupName">Name of academic group</param>
        /// <returns>Consults</returns>
        [Route()]
        [ResponseType(typeof(IEnumerable<ConsultDTO>))]
        public IHttpActionResult GetConsults(DateTime? date = null,string facultyTitle = null, string subjectName = null,
             string classroomTitle = null, string academicGroupName = null, int page = 1, int pageSize = 5)
        {

            var consults = consultsService.Filter(date, facultyTitle, subjectName,classroomTitle,
                academicGroupName, page, pageSize);


            if (consults.Count() == 0)
                return NotFound();
            else
                return Ok(consults);
        }

        /// <summary>
        /// Get consult by id
        /// </summary>
        /// <param name="id">Id of consult</param>
        /// <returns>Consult</returns>
        [Route("{id}")]
        [ResponseType(typeof(ConsultDTO))]
        public IHttpActionResult GetConsult(int id)
        {
            var consult = consultsService.Get(id);

            if (consult == null)
                return NotFound();
            else
                return Ok(consult);
        }
    }
}
