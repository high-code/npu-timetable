using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timetable.DAL.Entities
{
    public class Faculty
    {
        public int FacultyId { get; set; }

        public string FacultyName { get; set; }

        public ICollection<Specialty> Specialties { get; set; }

        public ICollection<Supervisor> Supervisors { get; set; }

        public ICollection<AcademicGroup> AcademicGroups { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<Consult> Consults { get; set; }

        public ICollection<Exam> Exams { get; set; }

        public ICollection<Chair> Chairs { get; set; }
    }
}
