using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Timetable.DAL.Entities
{
    [Table("Students")]
    public class Student : User
    {

        public int AcademicGroupId { get; set; }

        public AcademicGroup AcademicGroup { get; set; }


    }
}
