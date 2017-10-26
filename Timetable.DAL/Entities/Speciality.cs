using System;
using System.Collections.Generic;
using System.Linq;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timetable.DAL.Entities
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        public string SpecialtyCode { get; set; }

        public string SpecialtyTitle { get; set; }

        public string SpecialtyAbbreviation { get; set; }

        public ICollection<Faculty> Faculties { get; set; }

        public ICollection<Specialty> Specialties { get; set; }
    }
}
