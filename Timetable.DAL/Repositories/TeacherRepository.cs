using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Entities;
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

        public override IEnumerable<Teacher> GetMany(Expression<Func<Teacher, bool>> where)
        {
            return DbContext.Teachers
                .Include(t => t.Chairs)
                .Where(where);
        }

        public IEnumerable<Teacher> GetTeachersByChair(string chair)
        {
            return DbContext.Teachers.Where(t => t.Chairs.Any(c => c.ChairTitle.ToLower() == chair.ToLower()));
        }

        public IEnumerable<Teacher> GetTeachersByChairId(int chairId)
        {
            return DbContext.Teachers.Where(t => t.Chairs.Any(c => c.ChairId == chairId));
        }

        
    }

    
}
