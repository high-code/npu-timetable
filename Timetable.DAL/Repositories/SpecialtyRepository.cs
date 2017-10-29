using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;

namespace Timetable.DAL.Repositories
{
    public class SpecialtyRepository : RepositoryBase<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }


        public IEnumerable<Specialty> GetMany(Expression<Func<Specialty, bool>> where, int page, int pageSize)
        {
            return DbContext.Specialties
                .Where(where)
                .OrderBy(s => s.SpecialtyId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        public Specialty GetSpecialtyByTitle(string title)
        {
            return DbContext.Specialties.FirstOrDefault(s => s.SpecialtyTitle.ToLower() == title.ToLower());
        }

        public Specialty GetSpecialtyByCode(string code)
        {
            return DbContext.Specialties.FirstOrDefault(s => s.SpecialtyCode.ToLower() == code.ToLower());
        }

        public Specialty GetSpecialtyByAbbreviation(string abbreviation)
        {
            return DbContext.Specialties.FirstOrDefault(s => s.SpecialtyAbbreviation.ToLower() == abbreviation.ToLower());
        }
        
    }

}
