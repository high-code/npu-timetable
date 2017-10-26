using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Timetable.DAL.Entities
{
    public class Subject
    {

        public int SubjectId { get; set; }

        public string SubjectTitle { get; set; }

        public int SubjectTypeId { get; set; }

        public SubjectType SubjectType { get; set; }

        public int? ChairId { get; set; }

        public Chair Chair { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<Consult> Consults { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
