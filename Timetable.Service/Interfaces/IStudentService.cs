using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface IStudentService : IService<StudentDTO>
    {
        IEnumerable<StudentDTO> GetByAcademicGroupName(string academicGroupName);
        IEnumerable<StudentDTO> GetByAcademicGroupId(int academicGroupId);
    }
}
