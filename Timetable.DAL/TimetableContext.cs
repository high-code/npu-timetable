using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Entities;

namespace Timetable.DAL
{
    public class TimetableContext : DbContext
    {


        public TimetableContext() : base("name=TimetableDb") 
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Lesson> Lessons {get;set;}

        public DbSet<AcademicGroup> AcademicGroups { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Chair> Chairs { get; set; }

        public DbSet<Classroom> Classrooms { get; set; }

        public DbSet<Consult> Consults{ get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectType> SubjectTypes { get; set; }

        public DbSet<Supervisor> Supervisors { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
