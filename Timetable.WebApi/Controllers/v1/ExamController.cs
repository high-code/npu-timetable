using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Timetable.Service.DTO;
using Timetable.Service.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.WebApi.Routes;
namespace Timetable.WebApi.Controllers.v1
{
    [ApiV1RoutePrefix("exams")]
    public class ExamController : ApiController
    {

        IExamsService examsService;

        public ExamController(IExamsService examsService)
        {
            this.examsService = examsService;
        }


    }
}
