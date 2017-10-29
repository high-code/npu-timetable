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

        public IEnumerable<Consult> GetMany(Expression<Func<Consult, bool>> where, int page, int pageSize)
        {
            return DbContext.Consults
                .Include(c => c.AcademicGroup)
                .Include(c => c.Classroom)
                .Include(c => c.Faculty)
                .Include(c => c.Subject)
                .Where(where)
                .OrderBy(c => c.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

       
    }

}
