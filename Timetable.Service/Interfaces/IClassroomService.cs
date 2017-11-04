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

        PagedResult<Classroom, ClassroomDTO> Filter(string buildingTitle, int page, int pageSize);
        IEnumerable<ClassroomDTO> Filter(string buildingTitle);

    }
}
