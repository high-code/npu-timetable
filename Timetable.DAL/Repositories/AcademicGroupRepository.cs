using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Timetable.DAL.Repositories
{
    public class AcademicGroupRepository : RepositoryBase<AcademicGroup>, IAcademicGroupRepository
    {
        public AcademicGroupRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


        public override AcademicGroup GetById(int id)
        {
            return DbContext.AcademicGroups
                .Include(ag => ag.Faculty)
                .Include(ag => ag.Specialty)
                .FirstOrDefault(ag => ag.AcademicGroupId == id);
        }

        public override IEnumerable<AcademicGroup> GetMany(Expression<Func<AcademicGroup, bool>> where)
        {
            return DbContext.AcademicGroups
                .Include(ag => ag.Faculty)
                .Include(ag => ag.Specialty)
                .Where(where);
        }

        // Get methods (By name,faculty,specialty)       
        public AcademicGroup GetAcademicGroupByName(string name)
        {




            var academicGroup = DbContext.AcademicGroups
                .Where(ag => ag.GroupName.ToLower() == name.ToLower())
                .FirstOrDefault();


            return academicGroup;

        }


        public IEnumerable<AcademicGroup>  GetAcademicGroupsByFacultyName(string faculty)
        {
            var facultiesGroups  = new List<AcademicGroup>();

            facultiesGroups = DbContext.AcademicGroups
                .Where(ag => ag.Faculty.FacultyName.ToLower() == faculty.ToLower())
                .ToList();


            return facultiesGroups;
        }


        public IEnumerable<AcademicGroup> GetAcademicGroupsByFacultyId(int facultyId)
        {
            var facultiesGroup = new List<AcademicGroup>();

            facultiesGroup = DbContext.AcademicGroups
                .Where(ag => ag.FacultyId == facultyId)
                .ToList();

            return facultiesGroup;
        }

        public IEnumerable<AcademicGroup> GetAcademicGroupBySpecialtyTitle(string specialty)
        {
            var specialtiesGroups = new List<AcademicGroup>();

            specialtiesGroups = DbContext.AcademicGroups
                .Where(ag => ag.Specialty.SpecialtyTitle.ToLower() == specialty.ToLower())
                .ToList();

            return specialtiesGroups;
        }

       public IEnumerable<AcademicGroup> GetAcademicGroupBySpecialtyId(int specialtyId)
       {
           var specialtiesGroups = new List<AcademicGroup>();

           specialtiesGroups = DbContext.AcademicGroups
               .Where(ag => ag.SpecialtyId == specialtyId)
               .ToList();

           return specialtiesGroups;
       }
        /*
        public override void Add(AcademicGroup entity)
        {
            
            if(entity.ConsultsExamsTimetable != null)
            {
                var consultsExamsTimetable = entity.ConsultsExamsTimetable;
                entity.ConsultsExamsTimetable = new List<Consult>();

                foreach(var c in consultsExamsTimetable)
                {
                    var q = DbContext.ConsultsExamsTimetable.Find(c.Id);

                    if(q == null)
                    {
                        DbContext.ConsultsExamsTimetable.Attach(c);
                        DbContext.Entry(c).State = EntityState.Added;
                        entity.ConsultsExamsTimetable.Add(c);
                    }
                    else
                    {
                        DbContext.ConsultsExamsTimetable.Attach(q);
                        DbContext.Entry(q).State = EntityState.Unchanged;
                        entity.ConsultsExamsTimetable.Add(q);
                    }
                }
            }


            if(entity.Timetable != null)
            {
                var lessons = entity.Timetable;
                entity.Timetable = new List<Timetable>();


                foreach(var l in lessons)
                {
                    var q = DbContext.Timetable.Find(l.Id);

                    if(q == null)
                    {
                        DbContext.Timetable.Attach(l);
                        DbContext.Entry(l).State = EntityState.Added;
                        entity.Timetable.Add(l);
                    }
                    else
                    {
                        DbContext.Timetable.Attach(l);
                        DbContext.Entry(l).State = EntityState.Unchanged;
                        entity.Timetable.Add(q);
                    }
                }
            }

            if(entity.Students != null)
            {
                var students = entity.Students;
                entity.Students = new List<Student>();

                foreach(var s in students)
                {
                    var q = DbContext.Timetable.Find(s.UserId);

                    if (q == null)
                    {
                        DbContext.Students.Attach(s);
                        DbContext.Entry(s).State = EntityState.Added;
                        entity.Students.Add(s);
                    }
                    else
                    {
                        DbContext.Students.Attach(s);
                        DbContext.Entry(s).State = EntityState.Unchanged;
                        entity.Students.Add(s);
                    }
                }
            }

            base.Add(entity);

        }

        public override void Update(AcademicGroup entity)
        {
            AcademicGroup dbEntry = this.DbContext.AcademicGroups
                .Include(ag => ag.Students)
                .Include(ag => ag.ConsultsExamsTimetable)
                .Include(ag => ag.Lessons)
                .FirstOrDefault(ag => ag.AcademicGroupId == entity.AcademicGroupId);

            if(dbEntry != null)
            {

               this.DbContext.Entry(dbEntry).CurrentValues.SetValues(entity);

             
               var tempConsultsExams = dbEntry.ConsultsExamsTimetable.ToList();

                foreach(var t in tempConsultsExams)
                {
                    DbContext.Entry(t).State = GetConsultOrExamState(t, entity.ConsultsExamsTimetable);
                }

                var newConsultsExams = RepositoryHelper.GetNewConsultsOrExams(entity.ConsultsExamsTimetable,dbEntry.ConsultsExamsTimetable);

                newConsultsExams.ForEach(a =>
                    {
                        DbContext.ConsultsExamsTimetable.Attach(a);
                        DbContext.Entry(a).State = EntityState.Added;
                        dbEntry.ConsultsExamsTimetable.Add(a);
                    });

                var tempLessons = dbEntry.Lessons.ToList();

                foreach(var t in tempLessons)
                {
                    DbContext.Entry(t).State = GetLessonState(t, entity.Lessons);
                }

                var newLessons = RepositoryHelper.GetNewLessons(entity.Lessons, dbEntry.Lessons);

                newLessons.ForEach(a =>
                    {
                        DbContext.Lessons.Attach(a);
                        DbContext.Entry(a).State = EntityState.Added;
                        dbEntry.Lessons.Add(a);
                    });



                var tempStudents = dbEntry.Students.ToList();

                foreach(var t in tempStudents)
                {
                    DbContext.Entry(t).State = GetStudentState(t, entity.Students);
                }

                var newStudents = RepositoryHelper.GetNewStudents(entity.Students, dbEntry.Students);

                newStudents.ForEach(a =>
                    {
                        DbContext.Students.Attach(a);
                        DbContext.Entry(a).State = EntityState.Added;
                        dbEntry.Students.Add(a);
                    });
        
            }
        
        }

        public override void Delete(AcademicGroup entity)
        {
            base.Delete(entity);
        }

        public override void Delete(System.Linq.Expressions.Expression<Func<AcademicGroup, bool>> where)
        {
            base.Delete(where);
        }

       
        private static EntityState GetConsultOrExamState(Consult consultExam, IEnumerable<Consult> consultsExams)
        {
            if (consultsExams.Any(c => c.Id == consultExam.Id))
                return EntityState.Unchanged;
            else
                return EntityState.Deleted;
        }


        private static EntityState GetLessonState(Lesson lesson, IEnumerable<Lesson> timetable)
        {
            if (timetable.Any(t => t.Id == lesson.Id))
                return EntityState.Unchanged;
            else
                return EntityState.Deleted;
        }


        private static EntityState GetStudentState(Student student, IEnumerable<Student> students)
        {
            if (students.Any(s => s.UserId == student.UserId))
                return EntityState.Unchanged;
            else
                return EntityState.Modified;
        }

         */

    }

}

