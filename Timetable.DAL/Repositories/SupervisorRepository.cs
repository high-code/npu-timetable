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
    public class SupervisorRepository : UserRepository<Supervisor>, ISupervisorRepository
    {
        public SupervisorRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public override Supervisor GetById(int id)
        {
            return DbContext.Supervisors
                .Include(s => s.Faculty)
                .FirstOrDefault(s => s.UserId == id);
        }


        
    }


}
