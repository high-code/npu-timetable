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

    [ApiV1RoutePrefix("academicgroups")]
    public class AcademicGroupController : ApiController
    {
        IAcademicGroupService academicGroupService;

        public AcademicGroupController(IAcademicGroupService academicGroupService)
        {
            this.academicGroupService = academicGroupService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="facultyTitle"></param>
        /// <param name="specialtyTitle"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<AcademicGroupDTO>))]
        public IHttpActionResult GetAcademicGroups(string facultyTitle = null, string specialtyTitle = null, int page = 1, int pageSize = 5)
        {

            IEnumerable<AcademicGroupDTO> academicGroups = null;

            if (facultyTitle == null && specialtyTitle == null)
            {
                academicGroups = academicGroupService.GetAll();
            }
            else
            {
                academicGroups = academicGroupService.Filter(facultyTitle, specialtyTitle,page, pageSize);
            }


            if (academicGroups == null)
                return NotFound();
            else
            {
                int total = academicGroups.Count();
                int pageCount = total > 0
                    ? (int)Math.Ceiling(total / (double)pageSize)
                    : 0;


                var response = Request.CreateResponse(HttpStatusCode.OK, academicGroups);

                response.Headers.Add("X-Paging-PageNo", page.ToString());
                response.Headers.Add("X-Paging-PageSize", pageSize.ToString());
                response.Headers.Add("X-Paging-PageCount", pageCount.ToString());
                response.Headers.Add("X-Paging-TotalRecordCount", total.ToString());

                return ResponseMessage(response);
            }
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [ResponseType(typeof(AcademicGroupDTO))]
        public IHttpActionResult GetAcademicGroup(int id)
        {
            var academicGroup = academicGroupService.Get(id);

            if (academicGroup == null)
                return NotFound();
            else
                return Ok(academicGroup);
        }






    }
}
