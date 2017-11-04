using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Specifications;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.Interfaces;
using Timetable.Service.DTO;
using Timetable.Service.Infrastructure;
using AutoMapper;

namespace Timetable.Service.Services
{
    
    public class AcademicGroupService: IAcademicGroupService
    {
        private readonly IAcademicGroupRepository academicGroupRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILessonRepository lessonRepository;
        private readonly IConsultRepository consultRepository;
        private readonly IExamRepository examRepository;
        private readonly IMapper mapper;

        public AcademicGroupService(IAcademicGroupRepository academicGroupRepository,ILessonRepository lessonRepository,
            IConsultRepository consultRepository, IExamRepository examRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.academicGroupRepository = academicGroupRepository;
            this.lessonRepository = lessonRepository;
            this.consultRepository = consultRepository;
            this.examRepository = examRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int Count
        {
            get { return Count; }
        }

        public AcademicGroupDTO Get(int id)
        {

            var academicGroupDTO = academicGroupRepository.GetById(id);

            return mapper.Map<AcademicGroup, AcademicGroupDTO>(academicGroupDTO);
        }

        public IEnumerable<AcademicGroupDTO> GetAll()
        {
            var academicGroups = academicGroupRepository.GetAll();
            
            return mapper.Map<IEnumerable<AcademicGroup>, List<AcademicGroupDTO>>(academicGroups);
        }

        
        public PagedResult<AcademicGroup,AcademicGroupDTO> Filter(string facultyTitle, string specialtyTitle, int page, int pageSize)
        {

            AcademicGroupPagedSpecification specification = new AcademicGroupPagedSpecification(facultyTitle, specialtyTitle, page, pageSize);


            //  Create a paged result
            var pagedAcademicGroups = new PagedResult<AcademicGroup, AcademicGroupDTO>(specification, academicGroupRepository, mapper);

            return pagedAcademicGroups;
        }

        public IEnumerable<AcademicGroupDTO> Filter(string facultyTitle, string specialtyTitle)
        {
            AcademicGroupSpecification specification = new AcademicGroupSpecification(facultyTitle, specialtyTitle);

            var academicGroups = academicGroupRepository.GetMany(specification);

            return mapper.Map<IEnumerable<AcademicGroup>, IEnumerable<AcademicGroupDTO>>(academicGroups);
        }

        public IEnumerable<LessonDetailsDTO> GetAcademicGroupLessons(int id)
        {
            var spec = new LessonByAcademicGroupIdSpecification(id);

            var lessons = lessonRepository.GetMany(spec);

            return mapper.Map<IEnumerable<Lesson>,IEnumerable<LessonDetailsDTO>>(lessons);
        }

        public IEnumerable<ConsultDTO> GetAcademicGroupConsults(int id)
        {
            var spec = new ConsultByAcademicGroupIdSpecification(id);

            var consults = consultRepository.GetMany(spec);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ExamDTO> GetAcademicGroupExams(int id)
        {
            var spec = new ExamByAcademicGroupIdSpecification(id);

            var exams = examRepository.GetMany(spec);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }

        public void Create(AcademicGroupDTO group)
        {

            throw new NotImplementedException();
        }

        public void Update(AcademicGroupDTO group)
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
