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
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public override Subject GetById(int id)
        {
            return DbContext.Subjects
                .Include(s => s.Chair)
                .Include(s => s.SubjectType)
                .Include(s => s.Teacher)
                .FirstOrDefault(s => s.SubjectId == id);
        }

        public IEnumerable<Subject> List(IPagedSpecification<Subject> specification)
        {
            var query = RepositoryHelper.MakeIncludesQuery(specification, DbContext.Subjects);

            return query
                .Where(specification.Criteria)
                .OrderBy(s => s.SubjectId)
                .Skip(specification.Skip)
                .Take(specification.Take)
                .ToList();
        }
    }

    
}
