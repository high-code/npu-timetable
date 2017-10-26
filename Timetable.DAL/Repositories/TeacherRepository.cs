using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Repositories
{
    public class TeacherRepository :  UserRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

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
