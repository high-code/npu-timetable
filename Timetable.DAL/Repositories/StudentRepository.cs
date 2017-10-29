using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using System;
using System.Linq.Expressions;

namespace Timetable.DAL.Repositories
{
    public class StudentRepository : UserRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public override Student GetById(int id)
        {
            return DbContext.Students
                .Include(s => s.AcademicGroup)
                .FirstOrDefault(s => s.UserId == id);
        }



        public override IEnumerable<Student> GetMany(Expression<Func<Student, bool>> where, int page, int pageSize)
        {
            return DbContext.Students
                .Include(s => s.AcademicGroup)
                .Where(where)
                .OrderBy(s => s.UserId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
        }

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
