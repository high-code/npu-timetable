using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
namespace Timetable.DAL.Repositories
{
    public class StudentRepository : UserRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public IEnumerable<Student> GetStudentsByAcademicGroupName(string academicGroup)
        {
            return DbContext.Students.Where(s => s.AcademicGroup.GroupName.ToLower() == academicGroup.ToLower());
        }

        public IEnumerable<Student> GetStudentsByAcademicGroupId(int academicGroupId)
        {
            return DbContext.Students.Where(s => s.AcademicGroupId == academicGroupId);
        }

        public override void Add(Student entity)
        {
            base.Add(entity);
        }

        public override void Delete(Student entity)
        {
            base.Delete(entity);
        }
    }

   
}
