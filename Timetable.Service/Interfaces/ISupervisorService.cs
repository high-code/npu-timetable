using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface ISupervisorService : IService<SupervisorDTO>
    {
        IEnumerable<SupervisorDTO> GetByFacultyTitle(string faculty);
        IEnumerable<SupervisorDTO> GetByFacultyId(int facultyId);
    }
}
