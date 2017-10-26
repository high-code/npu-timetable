using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>, IUserRepository<Teacher>
    {
        IEnumerable<Teacher> GetTeachersByChair(string chair);
        IEnumerable<Teacher> GetTeachersByChairId(int id);
    
    }
}
