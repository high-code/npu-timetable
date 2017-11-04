using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Specifications;

using Timetable.DAL.Repositories;
using Timetable.DAL.Infrastructure;
using System.Data.Entity;
namespace Timetable.DAL.Repositories
{


    public static class RepositoryHelper
    {

        public static List<Consult> GetNewConsultsOrExams(IEnumerable<Consult> consultsExams,
                  IEnumerable<Consult> dbConsultsExams)
        {

            var newConsultsResults = new List<Consult>();

            foreach(var consultExam in consultsExams)
            {
                if (!dbConsultsExams.Any(dbce => dbce.Id == consultExam.Id))
                {
                    newConsultsResults.Add(consultExam);
                }
            }


            return newConsultsResults;
          
        }


        public static List<Lesson> GetNewLessons(IEnumerable<Lesson> lessons, IEnumerable<Lesson> dbLessons)
        {
            var newLessonResult = new List<Lesson>();

            foreach(var lesson in lessons)
            {
                if(!dbLessons.Any(l => l.Id == lesson.Id))
                {
                    newLessonResult.Add(lesson);
                }
            }

            return newLessonResult;
        }


        public static List<Student> GetNewStudents(IEnumerable<Student> students, IEnumerable<Student> dbStudents)
        {
            var newStudents = new List<Student>();

            foreach(var student in students)
            {
                if(!dbStudents.Any(s => s.UserId == student.UserId))
                {
                    newStudents.Add(student);
                }
            }

            return newStudents;
        }

        
        public static IQueryable<T> MakeIncludesQuery<T>(ISpecification<T> specification, IDbSet<T> dbSet)  where T : class
        {
            var query = specification.Includes
               .Aggregate(dbSet.AsQueryable(),
                 (current, include) => current.Include(include));

            query = specification.IncludeStrings
                .Aggregate(query,
                          (current, include) => current.Include(include));

            return query;

        }



    }
}
