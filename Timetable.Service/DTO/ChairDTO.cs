using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;

namespace Timetable.Service.DTO
{
    public class ChairDTO
    {
        public int ChairId { get; set; }

        public string ChairTitle { get; set; }

        public int FacultyId { get; set; }

        public string FacultyName { get; set; }
    }
}
