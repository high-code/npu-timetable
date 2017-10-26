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

        IEnumerable<ConsultDTO> GetByFacultyTitle(string faculty);
        IEnumerable<ConsultDTO> GetByFacultyId(int facultyId);
        IEnumerable<ConsultDTO> GetBySubjectTitle(string subject);
        IEnumerable<ConsultDTO> GetBySubjectId(int subjectId);
        IEnumerable<ConsultDTO> GetByClassroomTitle(string classroom);
        IEnumerable<ConsultDTO> GetByClassroomId(int classroomId);
        IEnumerable<ConsultDTO> GetByAcademicGroupName(string academicGroup);
        IEnumerable<ConsultDTO> GetByAcademicGroupId(int academicGroupId);
        IEnumerable<ConsultDTO> GetByDate(DateTime date);

        IEnumerable<ConsultDTO> Filter(DateTime? date, string facultyTitle, string subjectName,
            string classroomTitle, string academicGroupName);
        
    }
}
