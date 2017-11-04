using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.DAL.Specifications;
using Timetable.Service.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Entities;
using Timetable.Service.DTO;
using AutoMapper;
namespace Timetable.Service.Services
{
    public class ExamsService : IExamsService
    {
        IExamRepository examRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public ExamsService(IExamRepository examRepo, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.examRepository = examRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        public int Count
        {
            get { return Count; }
        }

        public ExamDTO Get(int id)
        {
            var exam = examRepository.GetById(id);

            return mapper.Map<Exam, ExamDTO>(exam);
        }

        public IEnumerable<ExamDTO> Filter(DateTime? date, string facultyTitle, string subjectName,
            string classroomTitle, string academicGroupName)
        {

            var examSpec = new ExamSpecification(date, facultyTitle, subjectName,
                classroomTitle, academicGroupName);

            var exams = examRepository.GetMany(examSpec);


            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);

        }

        public IEnumerable<ExamDTO> GetAll()
        {
            var exams = examRepository.GetAll();

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }

        public void Create(ExamDTO exam)
        {
            throw new NotImplementedException();
        }

        public void Update(ExamDTO exam)
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
