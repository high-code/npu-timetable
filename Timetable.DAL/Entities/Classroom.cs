using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Timetable.DAL.Entities
{
    public class Classroom
    {
        public int ClassroomId { get; set; }

        public string ClassroomTitle { get; set; }

        public int BuildingId { get; set; }

        public Building Building { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<Consult> Consults { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
