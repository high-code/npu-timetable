using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        
        public int Count
        {
            get { return Count; }
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


        public IEnumerable<ExamDTO> Filter(DateTime? date, string facultyTitle, string subjectName,
            string classroomTitle, string academicGroupName, int page, int pageSize)
        {
            Expression<Func<Exam, bool>> where = c => (date == null || c.Date == date) &&
                      (facultyTitle == null || c.Faculty.FacultyName.ToLower() == facultyTitle.ToLower()) &&
                      (subjectName == null || c.Subject.SubjectTitle.ToLower() == subjectName.ToLower()) &&
                      (classroomTitle == null || c.Classroom.ClassroomTitle.ToLower() == classroomTitle.ToLower()) &&
                      (academicGroupName == null || c.AcademicGroup.GroupName.ToLower() == academicGroupName.ToLower());

            var exams = examRepository.GetMany(where, page, pageSize);


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
