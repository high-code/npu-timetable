using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.Service.DTO;
using Timetable.Service.Infrastructure;
using Timetable.Service.Interfaces;

using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using AutoMapper;

namespace Timetable.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public StudentDTO Get(int id)
        {
            var student = studentRepository.GetById(id);

            return mapper.Map<Student, StudentDTO>(student);
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            var students = studentRepository.GetAll();


            return mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
        }

        public IEnumerable<StudentDTO> GetByAcademicGroupName(string name)
        {
            var students = studentRepository.GetStudentsByAcademicGroupName(name);

            return mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
        }


        public IEnumerable<StudentDTO> GetByAcademicGroupId(int academicGroupId)
        {
            var students = studentRepository.GetStudentsByAcademicGroupId(academicGroupId);

            return mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
        }

        public void Create(StudentDTO student)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentDTO student)
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
