using System;
using System.Collections.Generic;
using System.Linq;
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
