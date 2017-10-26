using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
namespace Timetable.DAL.Repositories
{
    public class ExamsRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamsRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<Exam> GetExamsBySubject(string subject)
        {
            return DbContext.Exams.Where(e => e.Subject.SubjectTitle.ToLower() == subject.ToLower());
        }

        public IEnumerable<Exam> GetExamsBySubjectId(int subjectId)
        {
            return DbContext.Exams.Where(e => e.SubjectId == subjectId);
        }
        public IEnumerable<Exam> GetExamsByFaculty(string faculty)
        {
            return DbContext.Exams.Where(e => e.Faculty.FacultyName.ToLower() == faculty.ToLower());
        }

        public IEnumerable<Exam> GetExamsByFacultyId(int facultyId)
        {
            return DbContext.Exams.Where(e => e.FacultyId == facultyId);
        }

        public IEnumerable<Exam> GetExamsByDate(DateTime date)
        {
            return DbContext.Exams.Where(e => e.Date == date);
        }

        public IEnumerable<Exam> GetExamsByClassroom(string classroom)
        {
            return DbContext.Exams.Where(e => e.Classroom.ClassroomTitle == classroom.ToLower());
        }

        public IEnumerable<Exam> GetExamsByClassroomId(int classroomId)
        {
            return DbContext.Exams.Where(e => e.ClassroomId == classroomId);
        }

        public IEnumerable<Exam> GetExamsByAcademicGroup(string academicGroup)
        {
            return DbContext.Exams.Where(e => e.AcademicGroup.GroupName.ToLower() == academicGroup.ToLower());
        }

        public IEnumerable<Exam> GetExamsByAcademicGroupId(int academicGroupId)
        {
            return DbContext.Exams.Where(e => e.AcademicGroupId == academicGroupId);
        }


        
    }
}
