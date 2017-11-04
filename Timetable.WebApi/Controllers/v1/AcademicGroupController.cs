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
        ILessonService lessonService;
        IExamsService examsService;
        IConsultsService consultsService;


        public AcademicGroupController(IAcademicGroupService academicGroupService, ILessonService lessonService, IExamsService examsService,
            IConsultsService consultsService)
        {
            this.academicGroupService = academicGroupService;
            this.lessonService = lessonService;
            this.examsService = examsService;
            this.consultsService = consultsService;
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

            var academicGroupsPaged = academicGroupService.Filter(facultyTitle, specialtyTitle, page, pageSize);


           
            if (academicGroupsPaged.Result == null)
                return NotFound();
            else
            {
                
                var response = Request.CreateResponse(HttpStatusCode.OK, academicGroupsPaged.Result);

                response.Headers.Add("X-Paging-PageNo", academicGroupsPaged.PageNumber.ToString());
                response.Headers.Add("X-Paging-PageSize", academicGroupsPaged.PageSize.ToString());
                response.Headers.Add("X-Paging-PageCount", academicGroupsPaged.PageCount.ToString());
                response.Headers.Add("X-Paging-TotalRecordCount", academicGroupsPaged.TotalRecordsCount.ToString());

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


        /// <summary>
        /// Returns lessons of academic group
        /// </summary>
        /// <param name="id">Academic group name</param>
        /// <returns></returns>
        [Route("{id:int}/lessons")]
        [ResponseType(typeof(IEnumerable<LessonDetailsDTO>))]
        public IHttpActionResult GetAcademicGroupLessons(int id)
        {
            var lessons = academicGroupService.GetAcademicGroupLessons(id);


            if (lessons == null)
                return NotFound();
            else
                return Ok(lessons);
        }


        /// <summary>
        /// Return academic group consults
        /// </summary>
        /// <param name="id">Academic group id</param>
        /// <returns>Consults</returns>
        [Route("{id:int}/consults")]
        [ResponseType(typeof(IEnumerable<ConsultDTO>))]
        public IHttpActionResult GetAcademicGroupConsults(int id)
        {
            var consults = academicGroupService.GetAcademicGroupConsults(id);

            if (consults.Count() == 0)
                return NotFound();
            else
                return Ok(consults);
        }


        /// <summary>
        /// Return academic group exams
        /// </summary>
        /// <param name="id">Academic group id</param>
        /// <returns>Exams</returns>
        [Route("{id:int}/exams")]
        [ResponseType(typeof(IEnumerable<ExamDTO>))]
        public IHttpActionResult GetAcademicGroupExams(int id)
        {
            var exams = academicGroupService.GetAcademicGroupExams(id);

            if (exams.Count() == 0)
                return NotFound();
            else
                return Ok(exams);
        }

        

        

    }
}
