using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Timetable.DAL.Entities
{
    public class SubjectType
    {
        public int SubjectTypeId { get; set; }

        public string SubjectTypeTitle { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
