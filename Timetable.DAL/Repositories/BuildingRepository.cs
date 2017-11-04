using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.DAL.Specifications;

namespace Timetable.DAL.Repositories
{
    public class BuildingRepository : RepositoryBase<Building>, IBuildingRepository
    {  
        public BuildingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
 
        }

      
    }

    
}
