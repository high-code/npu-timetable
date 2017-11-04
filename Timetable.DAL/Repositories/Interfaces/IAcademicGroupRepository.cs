using System;
using System.Collections.Generic;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Specifications;

namespace Timetable.DAL.Repositories.Interfaces
{

    public interface IAcademicGroupRepository :  IPageableRepository<AcademicGroup>
    {
        
    }
}
