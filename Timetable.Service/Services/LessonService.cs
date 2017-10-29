using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.Service.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Infrastructure;
using Timetable.Service.DTO;
using AutoMapper;
namespace Timetable.Service.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository lessonRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public LessonService(ILessonRepository lessonRepo,IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.lessonRepository = lessonRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int Count
        {
            get { return lessonRepository.Count; }
        }

        public LessonDetailsDTO Get(int id)
        {
            var lesson = lessonRepository.GetById(id);

            return mapper.Map<Lesson, LessonDetailsDTO>(lesson);
        }

        public IEnumerable<LessonDetailsDTO> GetByFacultyTitle(string faculty)
        {
           
           var lessons = lessonRepository.GetLessonsForFaculty(faculty);

           return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
            
        }

        public IEnumerable<LessonDetailsDTO> GetByFacultyId(int facultyId)
        {
            var lessons = lessonRepository.GetLessonsByFacultyId(facultyId);

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<LessonDetailsDTO> GetAll()
        {
            var lessons = lessonRepository.GetAll();

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        

        public IEnumerable<LessonDetailsDTO> Filter(string facultyTitle, string subjectName, string subjectTypeName,
           int? weekday, int? lessonOrder, bool? isEnumerator, string classroomTitle, string academicGroupName, int page, int pageSize)
        {

            Expression<Func<Lesson, bool>> where = l => 
                (facultyTitle == null || l.Faculty.FacultyName.ToLower() == facultyTitle.ToLower()) &&
                (subjectName == null || l.Subject.SubjectTitle.ToLower() == subjectName.ToLower()) &&
                (subjectTypeName == null || l.Subject.SubjectType.SubjectTypeTitle.ToLower() == subjectTypeName.ToLower()) &&
                (weekday == null || l.Weekday == weekday) &&
                (lessonOrder == null || l.LessonOrder == lessonOrder) &&
                (isEnumerator == null || l.IsEnumerator == isEnumerator) &&
                (classroomTitle == null || l.Classroom.ClassroomTitle.ToLower() == classroomTitle.ToLower()) &&
                (academicGroupName == null || l.AcademicGroup.GroupName.ToLower() == academicGroupName.ToLower());


            var lessons = lessonRepository.GetMany(where, page, pageSize);

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<LessonDetailsDTO> GetByAcademicGroupName(string academicGroup)
        {
            var lessons = lessonRepository.GetLessonsByAcademicGroup(academicGroup);

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<LessonDetailsDTO> GetByAcademicGroupId(int academicGroupId)
        {
            var lessons = lessonRepository.GetLessonsByAcademicGroupId(academicGroupId);

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<LessonDetailsDTO> GetByClassroomTitle(string classroom)
        {
            var lessons = lessonRepository.GetLessonsByClassroom(classroom);

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<LessonDetailsDTO> GetByClassroomId(int classroomId)
        {
            var lessons = lessonRepository.GetLessonsByClassroomId(classroomId);

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<LessonDetailsDTO> GetBySubjectTitle(string subject)
        {
            var lessons = lessonRepository.GetLessonsBySubject(subject);

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<LessonDetailsDTO> GetBySubjectId(int subjectId)
        {
            var lessons = lessonRepository.GetLessonsBySubjectId(subjectId);

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<LessonDetailsDTO> GetByTeacherId(int teacherId)
        {
            var lessons = lessonRepository.GetLessonsByTeacherId(teacherId);

            return mapper.Map<IEnumerable<Lesson>,IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public void Create(LessonDetailsDTO lesson)
        {
            throw new NotImplementedException();
        }

        public void Update(LessonDetailsDTO lesson)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }


    }
        
    
}
