using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IExamRepository : IRepository<Exam>
    {
        IEnumerable<Exam> GetExamsByFaculty(string faculty);
        IEnumerable<Exam> GetExamsByFacultyId(int id);
        IEnumerable<Exam> GetExamsBySubject(string subject);
        IEnumerable<Exam> GetExamsBySubjectId(int id);
        IEnumerable<Exam> GetExamsByClassroom(string classroom);
        IEnumerable<Exam> GetExamsByClassroomId(int classroomId);
        IEnumerable<Exam> GetExamsByAcademicGroup(string academicGroup);
        IEnumerable<Exam> GetExamsByAcademicGroupId(int academicGroupId);
        IEnumerable<Exam> GetExamsByDate(DateTime date);
    }
}
