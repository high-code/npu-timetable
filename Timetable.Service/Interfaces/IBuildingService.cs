using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface IBuildingService : IService<BuildingDTO>
    {
        BuildingDTO Get(string title);
        BuildingDTO GetBuildingByAddress(string address);       
    }
}
