using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories;
using Timetable.DAL.Specifications;
namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IChairRepository : IPageableRepository<Chair>
    {
       
    }
}
