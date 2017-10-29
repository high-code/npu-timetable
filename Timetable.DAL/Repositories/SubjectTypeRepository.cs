using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;

namespace Timetable.DAL.Repositories
{
    public class SubjectTypeRepository : RepositoryBase<SubjectType>, ISubjectTypeRepository
    {
        public SubjectTypeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }


        public IEnumerable<SubjectType> GetMany(Expression<Func<SubjectType, bool>> where, int page, int pageSize)
        {
            throw new NotImplementedException();
        }


    }

    
}
