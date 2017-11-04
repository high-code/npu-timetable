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
