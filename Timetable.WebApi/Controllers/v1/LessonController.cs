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
using Timetable.WebApi.Models;

namespace Timetable.WebApi.Controllers.v1
{

    [ApiV1RoutePrefix("lessons")]
    public class LessonController : ApiController
    {

        private readonly ILessonService lessonService;

        public LessonController(ILessonService lessonService)
        {
            this.lessonService = lessonService;
        }

        

        /// <summary>
        /// Get lesson by id
        /// </summary>
        /// <param name="id">Id of lesson</param>
        /// <returns>Lesson</returns>
        [Route("{id}")]
        [ResponseType(typeof(LessonDetailsDTO))]
        public IHttpActionResult GetLesson(int id)
        {
            var lessonDetails = lessonService.Get(id);

            if (lessonDetails == null)
                return NotFound();
            else
                return Ok(lessonDetails);

        }
        /// <summary>
        /// Get lessons by filters
        /// </summary>
        /// <param name="facultyTitle">Title of faculty</param>
        /// <param name="subjectName">Title of subject</param>
        /// <param name="subjectTypeName"></param>
        /// <param name="weekday">Weekday(0 - Monday, 1 - Thursday etc.)</param>
        /// <param name="lessonOrder">Order of lesson</param>
        /// <param name="isEnumerator">Enumerator or numerator</param>
        /// <param name="classroomTitle">Title of classroom</param>
        /// <param name="academicGroupName">Title of group</param>
        /// <param name="page">Page you want to retrieve</param>
        /// <param name="pageSize">Count of items on the page</param>
        /// <returns></returns>
        [Route()]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<LessonDetailsDTO>))]
        public IHttpActionResult GetLessons(string facultyTitle = null, string subjectName = null, string subjectTypeName = null,
           int? weekday = null, int? lessonOrder = null, bool? isEnumerator = null, string classroomTitle = null, string academicGroupName = null, int page = 1, int pageSize = 10)
        {

            var lessonsDetailsPaged = lessonService.Filter(facultyTitle, subjectName, subjectTypeName,
                weekday, lessonOrder, isEnumerator, classroomTitle, academicGroupName, page, pageSize);


            var response = Request.CreateResponse(HttpStatusCode.OK, lessonsDetailsPaged.Result);

            response.Headers.Add("X-Paging-PageNo", lessonsDetailsPaged.PageNumber.ToString());
            response.Headers.Add("X-Paging-PageSize", lessonsDetailsPaged.PageSize.ToString());
            response.Headers.Add("X-Paging-PageCount", lessonsDetailsPaged.PageCount.ToString());
            response.Headers.Add("X-Paging-TotalRecordCount", lessonsDetailsPaged.TotalRecordsCount.ToString());

            if (lessonsDetailsPaged.Result.Count() == 0)
                return NotFound();
            else
                return ResponseMessage(response);
                
        }
    }
}
