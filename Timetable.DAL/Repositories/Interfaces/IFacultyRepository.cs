using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Repositories;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        Faculty GetFacultyByName(string name);


        
    }
}
