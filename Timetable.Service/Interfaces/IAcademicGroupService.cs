using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface IAcademicGroupService : IService<AcademicGroupDTO>
    {
     
        PagedResult<AcademicGroup, AcademicGroupDTO> Filter(string facultyTitle, string specialtyTitle, int page, int pageSize);
        IEnumerable<AcademicGroupDTO> Filter(string facultyTitle, string specialtyTitle);
        IEnumerable<LessonDetailsDTO> GetAcademicGroupLessons(int id);
        IEnumerable<ConsultDTO> GetAcademicGroupConsults(int id);
        IEnumerable<ExamDTO> GetAcademicGroupExams(int id);
        
    }
}
