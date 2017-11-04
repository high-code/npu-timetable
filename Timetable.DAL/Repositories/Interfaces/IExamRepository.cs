using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IExamRepository : IPageableRepository<Exam>
    {
        
    }
}
