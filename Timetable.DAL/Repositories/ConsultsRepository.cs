using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Timetable.DAL.Repositories
{
    public class ConsultsRepository : RepositoryBase<Consult>, IConsultRepository
    {
        public ConsultsRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public override Consult GetById(int id)
        {
            return DbContext.Consults
                .Include(c => c.AcademicGroup)
                .Include(c => c.Classroom)
                .Include(c => c.Faculty)
                .Include(c => c.Subject)
                .FirstOrDefault(c => c.Id == id);
        }

        public override IEnumerable<Consult> GetMany(Expression<Func<Consult, bool>> where)
        {
            return DbContext.Consults
                .Include(c => c.AcademicGroup)
                .Include(c => c.Classroom)
                .Include(c => c.Faculty)
                .Include(c => c.Subject)
                .Where(where);
        }

        public IEnumerable<Consult> GetConsultsByFaculty(string faculty)
        {
            return DbContext.Consults.Where(c => c.Faculty.FacultyName.ToLower() == faculty.ToLower());
        }

        public IEnumerable<Consult> GetConsultsByFacultyId(int facultyId)
        {
            return DbContext.Consults.Where(c => c.FacultyId == facultyId);
        }

        public IEnumerable<Consult> GetConsultsByClassroom(string classroom)
        {
            return DbContext.Consults.Where(c => c.Classroom.ClassroomTitle.ToLower() == classroom.ToLower());
        }

        public IEnumerable<Consult> GetConsultsByClassroomId(int classroomId)
        {
            return DbContext.Consults.Where(c => c.ClassroomId == classroomId);
        }

        public IEnumerable<Consult> GetConsultsBySubject(string subject)
        {
            return DbContext.Consults.Where(c => c.Subject.SubjectTitle.ToLower() == subject.ToLower());
        }

        public IEnumerable<Consult> GetConsultsBySubjectId(int subjectId)
        {
            return DbContext.Consults.Where(c => c.SubjectId == subjectId);
        }

        public IEnumerable<Consult> GetConsultsByDate(DateTime date)
        {
            return DbContext.Consults.Where(c => c.Date == date);
        }

        public IEnumerable<Consult> GetConsultsByAcademicGroup(string groupName)
        {
            return DbContext.Consults.Where(c => c.AcademicGroup.GroupName.ToLower() == groupName.ToLower());
        }

        public IEnumerable<Consult> GetConsultsByAcademicGroupId(int academicGroupId)
        {
            return DbContext.Consults.Where(c => c.AcademicGroupId == academicGroupId);
        }
       
    }

}
