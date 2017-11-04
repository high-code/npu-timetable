using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface IConsultsService : IService<ConsultDTO>
    {

        //PagedResult<Consult, ConsultDTO> Filter(DateTime? date, string facultyTitle, string subjectName,
        //    string classroomTitle, string academicGroupName, int page, int pageSize);
        IEnumerable<ConsultDTO> Filter(DateTime? date, string facultyTitle, string subjectName,
            string classroomTitle, string academicGroupName);
    }
}
