using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Timetable.Service.Interfaces;
using Timetable.Service.DTO;

namespace Timetable.WebApi.Controllers
{
    [RoutePrefix("api/classrooms")]
    public class ClassroomController : ApiController
    {
        IClassroomService classroomService;

        public ClassroomController(IClassroomService classroomServ)
        {
            this.classroomService = classroomServ;
            
        }

        /// <summary>
        /// Get all classrooms in university
        /// </summary>
        /// <returns> Classrooms </returns
        [Route("")]
        public IEnumerable<ClassroomDTO> GetClassrooms(string buildingTitle = null)
        {

            if(buildingTitle != null)
            {
                return classroomService.GetByBuildingTitle(buildingTitle);
            }
            else
            {
                return classroomService.GetAll();
            }
            
        }

        [Route("{id:int}")]
        public ClassroomDTO GetClassroom(int id)
        {
            return classroomService.Get(id);
        }
       
        

        



        
    }
}
