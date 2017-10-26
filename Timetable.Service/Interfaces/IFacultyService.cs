using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;
namespace Timetable.Service.Interfaces
{
    public interface IFacultyService : IService<FacultyDTO>
    {
       
        FacultyDTO Get(string name);

    }
}
