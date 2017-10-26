using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface IChairService : IService<ChairDTO>
    {
       
        IEnumerable<ChairDTO> GetByFacultyName(string faculty);
        IEnumerable<ChairDTO> GetByFacultyId(int facultyId);
        ChairDTO Get(string title);

    }
}
