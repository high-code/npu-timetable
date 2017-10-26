using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        Specialty GetSpecialtyByTitle(string title);
        Specialty GetSpecialtyByCode(string code);
        Specialty GetSpecialtyByAbbreviation(string abbr);
    }
}
