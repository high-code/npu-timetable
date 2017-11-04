using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timetable.DAL.Entities
{

    public class Supervisor : User
    {
        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }
    }
}
