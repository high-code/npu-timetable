using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Timetable.Service.DTO;
using Timetable.Service.Interfaces;
namespace Timetable.WebApi.Controllers
{

    [RoutePrefix("api/academicgroups")]
    public class AcademicGroupController : ApiController
    {
        IAcademicGroupService academicGroupService;

        public AcademicGroupController(IAcademicGroupService academicGroupService)
        {
            this.academicGroupService = academicGroupService;
        }


        [Route("")]
        public IEnumerable<AcademicGroupDTO> GetAcademicGroups(string facultyTitle = null, string specialtyTitle = null)
        {

            IEnumerable<AcademicGroupDTO> academicGroupsDTOs = null;

            if (facultyTitle == null && specialtyTitle == null)
            {
                academicGroupsDTOs = academicGroupService.GetAll();
            }
            else
            {
                academicGroupsDTOs = academicGroupService.Filter(facultyTitle, specialtyTitle);

            }




            return academicGroupsDTOs;
        }


        [Route("{id:int}")]
        public AcademicGroupDTO GetAcademicGroup(int id)
        {
            var academicGroup = academicGroupService.Get(id);

            return academicGroup;
        }






    }
}
