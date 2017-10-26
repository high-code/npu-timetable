using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Repositories;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Building GetBuildingByTitle(string title);
        Building GetBuildingByAddress(string address);
    }
}
