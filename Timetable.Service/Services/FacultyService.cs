using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.Service.Interfaces;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Entities;
using Timetable.Service.DTO;
using AutoMapper;
namespace Timetable.Service.Services
{
    public class FacultyService : IFacultyService
    {
        IFacultyRepository facultyRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public FacultyService(IFacultyRepository facultyRepo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.facultyRepository = facultyRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public FacultyDTO Get(int id)
        {
            var faculty = facultyRepository.GetById(id);

            return mapper.Map<Faculty, FacultyDTO>(faculty); 
        }

        public FacultyDTO Get(string name)
        {
            var faculty = facultyRepository.GetFacultyByName(name);

            return mapper.Map<Faculty, FacultyDTO>(faculty);
        }

        public IEnumerable<FacultyDTO> GetAll()
        {
            var faculties = facultyRepository.GetAll();

            return mapper.Map<IEnumerable<Faculty>, IEnumerable<FacultyDTO>>(faculties);
        }

        public void Create(FacultyDTO faculty)
        {
            throw new NotImplementedException();
        }

        public void Update(FacultyDTO faculty)
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
