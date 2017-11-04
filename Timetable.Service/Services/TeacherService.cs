using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.Interfaces;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.Service.DTO;
using AutoMapper;

namespace Timetable.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TeacherService(ITeacherRepository teacherRepo, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.teacherRepository = teacherRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public TeacherDTO Get(int id)
        {
            var teacher = teacherRepository.GetById(id);



            return Mapper.Map<Teacher, TeacherDTO>(teacher);
        }

 

        public IEnumerable<TeacherDTO> GetAll()
        {
            var teachers = teacherRepository.GetAll();

            return mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherDTO>>(teachers);
        }

        public void Create(TeacherDTO teacher)
        {
            throw new NotImplementedException();
        }

        public void Update(TeacherDTO teacher)
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
