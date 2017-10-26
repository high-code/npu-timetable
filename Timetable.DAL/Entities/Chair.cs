using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timetable.DAL.Entities
{
    public class Chair
    {
        public int ChairId { get; set; }

        public string ChairTitle { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

        public int FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }
    }
}
