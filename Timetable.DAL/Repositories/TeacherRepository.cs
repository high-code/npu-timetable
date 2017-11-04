using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Entities;
using Timetable.DAL.Specifications;
using System.Linq.Expressions;

namespace Timetable.DAL.Repositories
{
    public class TeacherRepository :  UserRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public override Teacher GetById(int id)
        {
            return DbContext.Teachers
                .Include(t => t.Chairs)
                .FirstOrDefault(t => t.UserId == id);
        }


        
    }

    
}
