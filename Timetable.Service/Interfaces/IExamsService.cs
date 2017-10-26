using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface IExamsService : IService<ExamDTO>
    {
        
        IEnumerable<ExamDTO> GetByFacultyTitle(string faculty);
        IEnumerable<ExamDTO> GetByFacultyId(int facultyId);
        IEnumerable<ExamDTO> GetBySubjectTitle(string subject);
        IEnumerable<ExamDTO> GetBySubjectId(int subjectId);
        IEnumerable<ExamDTO> GetByClassroomTitle(string classroom);
        IEnumerable<ExamDTO> GetByClassroomId(int classroomId);
        IEnumerable<ExamDTO> GetByAcademicGroupName(string academicGroup);
        IEnumerable<ExamDTO> GetByAcademicGroupId(int academicGroupId);
        IEnumerable<ExamDTO> GetByDate(DateTime date);
        
    }
}
