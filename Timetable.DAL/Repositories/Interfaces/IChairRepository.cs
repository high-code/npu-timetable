using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IChairRepository : IRepository<Chair>
    {
        Chair GetChairByTitle(string title);
        IEnumerable<Chair> GetChairsByFacultyName(string faculty);
        IEnumerable<Chair> GetChairsByFacultyId(int facultyId);
    }
}
