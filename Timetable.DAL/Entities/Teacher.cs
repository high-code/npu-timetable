using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timetable.DAL.Entities
{
    [Table("Teachers")]
    public class Teacher : User
    {
        public ICollection<Chair> Chairs { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
