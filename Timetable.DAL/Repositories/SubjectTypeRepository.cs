using System;
using System.Collections.Generic;
using System.Linq;
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

        public SubjectType GetSubjectTypeByName(string name)
        {
            return DbContext.SubjectTypes.FirstOrDefault(st => st.SubjectTypeTitle.ToLower() == name.ToLower());
        }


    }

    
}
