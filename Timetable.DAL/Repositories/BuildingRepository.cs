using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Repositories
{
    public class BuildingRepository : RepositoryBase<Building>, IBuildingRepository
    {  
        public BuildingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
 
        }

         
        public IEnumerable<Building> GetMany(Expression<Func<Building, bool>> where, int page, int pageSize)
        {
            return DbContext.Buildings
                .Where(where)
                .OrderBy(b => b.BuildingId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();               
        }

        public Building GetBuildingByTitle(string title)
        {

            return DbContext.Buildings.FirstOrDefault(b => b.BuildingTitle == title);

        }

        public Building GetBuildingByAddress(string address)
        {
            return DbContext.Buildings.FirstOrDefault(b => b.BuildingAddress == address);
        }


        
    }

    
}
