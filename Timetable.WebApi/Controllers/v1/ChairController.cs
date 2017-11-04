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

    [ApiV1RoutePrefix("chairs")]
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
                var chairs = chairService.Filter(facultyTitle);

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


        /// <summary>
        /// Returns teachers of chair
        /// </summary>
        /// <param name="id">Chair id</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Count of items on the page</param>
        /// <returns></returns>
        [Route("{id:int}/teachers")]
        [ResponseType(typeof(IEnumerable<TeacherDTO>))]
        public IHttpActionResult GetChairTeachers(int id, int page = 1, int pageSize = 5)
        {
            var teachersPaged = chairService.GetChairTeachers(id, page, pageSize);


            if (teachersPaged.Result.Count() == 0)
                return NotFound();

            else
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, teachersPaged.Result);

                response.Headers.Add("X-Paging-PageNo", teachersPaged.PageNumber.ToString());
                response.Headers.Add("X-Paging-PageSize", teachersPaged.PageSize.ToString());
                response.Headers.Add("X-Paging-PageCount", teachersPaged.PageCount.ToString());
                response.Headers.Add("X-Paging-TotalRecordCount", teachersPaged.TotalRecordsCount.ToString());

                return ResponseMessage(response);
            }

        }
    }
}
