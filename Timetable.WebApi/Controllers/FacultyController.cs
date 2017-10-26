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

    [RoutePrefix("api/faculties")]
    public class FacultyController : ApiController
    {
        IFacultyService facultyService;

        public FacultyController(IFacultyService facultyServ)
        {
            facultyService = facultyServ;
        }
        


        /// <summary>
        /// Returns all faculties in university
        /// </summary>
        /// <returns>Faculty</returns>
        [Route()]
        [ResponseType(typeof(IEnumerable<FacultyDTO>))]
        public IHttpActionResult GetFaculties()
        {
            var faculties = facultyService.GetAll();

            if (faculties == null)
                return NotFound();
            else
                return Ok(faculties);
        }


        /// <summary>
        /// Return faculty by id
        /// </summary>
        /// <param name="id">Id of faculty</param>
        /// <returns>Faculty</returns>
        [Route("{id}")]
        [ResponseType(typeof(FacultyDTO))]
        public IHttpActionResult GetFaculty(int id)
        {
            var faculty = facultyService.Get(id);

            if (faculty == null)
                return NotFound();
            else
                return Ok(faculty);
        }

    }
}
