﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Timetable.Service.Interfaces;
using Timetable.Service.DTO;

namespace Timetable.WebApi.Controllers
{
    /// <summary>
    /// Operating with classrooms in university
    /// </summary>
    [RoutePrefix("api/classrooms")]
    public class ClassroomController : ApiController
    {
        IClassroomService classroomService;

        public ClassroomController(IClassroomService classroomServ)
        {
            this.classroomService = classroomServ;
            
        }

        /// <summary>
        /// Get all classrooms
        /// </summary>
        /// <param name="buildingTitle">Use it to get classrooms of building</param>
        /// <param name="page">Specify page to return</param>
        /// <param name="pageSize">Specify how many items on page you want</param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(IEnumerable<ClassroomDTO>))]
        public IHttpActionResult GetClassrooms(string buildingTitle = null, int page = 1, int pageSize = 5)
        {
            IEnumerable<ClassroomDTO> classrooms;

            if(buildingTitle != null)
            {
                classrooms = classroomService.GetByBuildingTitle(buildingTitle);
            }
            else
            {
                classrooms = classroomService.GetAll();
            }

            if (classrooms == null)
                return NotFound();
            else
                return Ok(classrooms);
            
        }


        /// <summary>
        /// Return classroom by id
        /// </summary>
        /// <param name="id">Id of classroom</param>
        /// <returns>Classrooom</returns>
        [Route("{id:int}")]
        [ResponseType(typeof(ClassroomDTO))]
        public IHttpActionResult GetClassroom(int id)
        {
            var classroom = classroomService.Get(id);

            if (classroom == null)
                return NotFound();
            else
                return Ok(classroom);

        }
       
        

        



        
    }
}
