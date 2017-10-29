using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Timetable.DAL.Repositories
{
    public class LessonsRepository : RepositoryBase<Lesson>, ILessonRepository
    {
        public LessonsRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        
        


        public override Lesson GetById(int id)
        {
            
            return DbContext.Lessons
                .Include(l => l.AcademicGroup)
                .Include(l => l.Classroom)
                .Include(l => l.Faculty)
                .Include(l => l.Subject)
                .FirstOrDefault(l => l.Id == id);
        }

        public  IEnumerable<Lesson> GetMany(Expression<Func<Lesson, bool>> where, int page, int pageSize)
        {
            return DbContext.Lessons
                .Include(l => l.AcademicGroup)
                .Include(l => l.Classroom.Building)
                .Include(l => l.Subject.SubjectType)
                .Include(l => l.Classroom)
                .Include(l => l.Faculty)
                .Include(l => l.Subject)
                .Where(where)
                .OrderBy(l => l.Id)
                .Skip(pageSize * (page - 1))
                .Take(pageSize);
        }


        public IEnumerable<Lesson> GetLessonsForFaculty(string faculty)
        {
            return DbContext.Lessons.Where(t => t.Faculty.FacultyName.ToLower() == faculty.ToLower());
        }

        public IEnumerable<Lesson> GetLessonsByFacultyId(int facultyId)
        {
            return DbContext.Lessons.Where(t => t.FacultyId == facultyId);
        }

        public IEnumerable<Lesson> GetLessonsByAcademicGroup(string academicGroup)
        {
            return DbContext.Lessons.Where(t => t.AcademicGroup.GroupName.ToLower() == academicGroup.ToLower());
        }

        public IEnumerable<Lesson> GetLessonsByAcademicGroupId(int academicGroupId)
        {
            return DbContext.Lessons.Where(t => t.AcademicGroupId == academicGroupId);
        }

        public IEnumerable<Lesson> GetLessonsByClassroom(string classroom)
        {
            return DbContext.Lessons.Where(t => t.Classroom.ClassroomTitle.ToLower() == classroom.ToLower());
        }

        public IEnumerable<Lesson> GetLessonsByClassroomId(int classroomId)
        {
            return DbContext.Lessons.Where(t => t.ClassroomId == classroomId);
        }

        public IEnumerable<Lesson> GetLessonsBySubject(string subject)
        {
            return DbContext.Lessons.Where(t => t.Subject.SubjectTitle.ToLower() == subject.ToLower());
        }

        public IEnumerable<Lesson> GetLessonsBySubjectId(int subjectId)
        {
            return DbContext.Lessons.Where(t => t.SubjectId == subjectId);
        }

        
        public IEnumerable<Lesson> GetLessonsByTeacherId(int teacherId)
        {
            return DbContext.Lessons.Where(t => t.Subject.TeacherId == teacherId);

        }
    }

    
}
