using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Specifications;

namespace Timetable.DAL.Repositories
{
    public class SpecialtyRepository : RepositoryBase<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }


        public IEnumerable<Specialty> List(IPagedSpecification<Specialty> specification)
        {
            var query = RepositoryHelper.MakeIncludesQuery(specification, DbContext.Specialties);

            return query
                .Where(specification.Criteria)
                .OrderBy(s => s.SpecialtyId)
                .Skip(specification.Skip)
                .Take(specification.Take)
                .ToList();
        }

    }

}
