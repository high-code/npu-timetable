using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.Service.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Specifications;
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

       

        public IEnumerable<LessonDetailsDTO> GetAll()
        {
            var lessons = lessonRepository.GetAll();

            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
        }

        

        public PagedResult<Lesson,LessonDetailsDTO> Filter(string facultyTitle, string subjectName, string subjectTypeName,
           int? weekday, int? lessonOrder, bool? isEnumerator, string classroomTitle, string academicGroupName, int page, int pageSize)
        {

            var lessonSpec = new LessonPagedSpecification(facultyTitle, subjectName
                , subjectTypeName, weekday, lessonOrder, isEnumerator, classroomTitle, academicGroupName,
                page, pageSize);

            var lessons = lessonRepository.List(lessonSpec);

            var pagedLessons = new PagedResult<Lesson, LessonDetailsDTO>(lessonSpec, lessonRepository,
                mapper);

            return pagedLessons;
        }

        public IEnumerable<LessonDetailsDTO> Filter(string facultyTitle, string subjectName, string subjectTypeName,
           int? weekday, int? lessonOrder, bool? isEnumerator, string classroomTitle, string academicGroupName)
        {

            var lessonSpec = new LessonSpecification(facultyTitle, subjectName
                , subjectTypeName, weekday, lessonOrder, isEnumerator, classroomTitle, academicGroupName);


            var lessons = lessonRepository.GetMany(lessonSpec);


            return mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDetailsDTO>>(lessons);
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
