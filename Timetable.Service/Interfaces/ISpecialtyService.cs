using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.DTO;
using Timetable.Service.Infrastructure;

namespace Timetable.Service.Interfaces
{
    public interface ISpecialtyService : IService<SpecialtyDTO>
    {
        
        SpecialtyDTO GetSpecialtyByTitle(string title);

        SpecialtyDTO GetSpecialtyByCode(string code);

        SpecialtyDTO GetSpecialtyByAbbreviation(string abbreviation);


    }
}
