using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Timetable.DAL.Entities
{
    public class AcademicGroup
    {
        public int AcademicGroupId { get; set; }

        public string GroupName { get; set; }

        [Range(1,6)]
        public int Course { get; set; }

        public int StudentsAmount { get; set; }

        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<Exam> Exams { get; set; }

        public ICollection<Consult> Consults { get; set; }
        
    }
}
