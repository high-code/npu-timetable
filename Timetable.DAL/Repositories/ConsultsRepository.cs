using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Specifications;
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

        public IEnumerable<Consult> List(IPagedSpecification<Consult> specification)
        {
            var query = RepositoryHelper.MakeIncludesQuery(specification, DbContext.Consults);

            return query
                .Where(specification.Criteria)
                .OrderBy(c => c.Id)
                .Skip(specification.Skip)
                .Take(specification.Take)
                .ToList();
        }
       
    }

}
