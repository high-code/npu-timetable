using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.DAL.Repositories;
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

        public ExamDTO Get(int id)
        {
            var exam = examRepository.GetById(id);

            return mapper.Map<Exam, ExamDTO>(exam);
        }


        public IEnumerable<ExamDTO> GetByFacultyTitle(string faculty)
        {
            var exams = examRepository.GetExamsByFaculty(faculty);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }

        public IEnumerable<ExamDTO> GetByFacultyId(int facultyId)
        {
            var exams = examRepository.GetExamsByFacultyId(facultyId);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);

        }

        public IEnumerable<ExamDTO> GetByClassroomTitle(string classroom)
        {
            var exams = examRepository.GetExamsByClassroom(classroom);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }

        public IEnumerable<ExamDTO> GetByClassroomId(int classroomId)
        {
            var exams = examRepository.GetExamsByClassroomId(classroomId);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }

        public IEnumerable<ExamDTO> GetBySubjectTitle(string subject)
        {
            var exams = examRepository.GetExamsBySubject(subject);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }

        public IEnumerable<ExamDTO> GetBySubjectId(int subjectId)
        {
            var exams = examRepository.GetExamsBySubjectId(subjectId);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }
        public IEnumerable<ExamDTO> GetByAcademicGroupName(string academicGroup)
        {
            var exams = examRepository.GetExamsByAcademicGroup(academicGroup);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }

        public IEnumerable<ExamDTO> GetByAcademicGroupId(int academicGroupId)
        {
            var exams = examRepository.GetExamsByAcademicGroupId(academicGroupId);

            return mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams);
        }

        public IEnumerable<ExamDTO> GetByDate(DateTime date)
        {
            var exams = examRepository.GetExamsByDate(date);

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
