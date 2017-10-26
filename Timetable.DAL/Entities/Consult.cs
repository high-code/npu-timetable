using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timetable.DAL.Entities
{
    public class Consult
    {
        public int Id { get; set; }

        
        public int? FacultyId { get; set; }


        public Faculty Faculty { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public DateTime Date { get; set; }
        
        public int ClassroomId { get; set; }

        public Classroom Classroom { get; set; }

        public int AcademicGroupId { get; set; }

        public AcademicGroup AcademicGroup { get; set; }
    }
}
