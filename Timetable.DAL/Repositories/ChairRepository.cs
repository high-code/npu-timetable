using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Specifications;
using System.Data.Entity;
namespace Timetable.DAL.Repositories
{
    public class ChairRepository : RepositoryBase<Chair>, IChairRepository
    {

        public ChairRepository(IDbFactory dbFactory) : base(dbFactory)
        { }


        public override Chair GetById(int id)
        {
            return DbContext.Chairs
                .Include(c => c.Faculty)
                .FirstOrDefault(c => c.ChairId == id);
        }

        

        public override IEnumerable<Chair> GetAll()
        {
            
            return DbContext.Chairs
                .Include(c => c.Faculty);
        }
       
        
        public IEnumerable<Chair> List(IPagedSpecification<Chair> specification)
        {
            var query = RepositoryHelper.MakeIncludesQuery<Chair>(specification, DbContext.Chairs);


            return query.Where(specification.Criteria)
                        .OrderBy(c => c.ChairId)
                        .Skip(specification.Skip)
                        .Take(specification.Take);
        }

        

    }

    

}
