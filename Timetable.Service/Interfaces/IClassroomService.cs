using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;
namespace Timetable.Service.Interfaces
{
    public interface IClassroomService : IService<ClassroomDTO>
    {

        IEnumerable<ClassroomDTO> GetByBuildingTitle(string building);
        IEnumerable<ClassroomDTO> GetByBuildingId(int id);
        ClassroomDTO Get(string title);

    }
}
