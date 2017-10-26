using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Timetable.DAL.Entities
{
    public class Building
    {
        public int BuildingId { get; set; }

        public string BuildingTitle { get; set; }

        public string BuildingAddress { get; set; }

        public ICollection<Classroom> Classrooms { get; set; }
    }
}
