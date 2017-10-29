using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Service.DTO;
using Timetable.Service.Interfaces;
using Timetable.Service.Infrastructure;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Entities;
using AutoMapper;

namespace Timetable.Service.Services
{
    public class SupervisorService : ISupervisorService
    {
        
        private readonly ISupervisorRepository supervisorRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SupervisorService(ISupervisorRepository supervisorRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.supervisorRepository = supervisorRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int Count
        {
            get { return Count; }
        }

        public SupervisorDTO Get(int id)
        {
            var supervisor = supervisorRepository.GetById(id);

            return mapper.Map<Supervisor, SupervisorDTO>(supervisor);
        }

        public IEnumerable<SupervisorDTO> GetAll()
        {
            var supervisors = supervisorRepository.GetAll();

            return mapper.Map<IEnumerable<Supervisor>, IEnumerable<SupervisorDTO>>(supervisors);
        }

        public IEnumerable<SupervisorDTO> GetByFacultyTitle(string facultyTitle)
        {
            var supervisors = supervisorRepository.GetSupervisorsByFaculty(facultyTitle);

            return mapper.Map<IEnumerable<Supervisor>, IEnumerable<SupervisorDTO>>(supervisors);
        }

        public IEnumerable<SupervisorDTO> GetByFacultyId(int facultyId)
        {
            var supervisors = supervisorRepository.GetSupervisorsByFacultyId(facultyId);

            return mapper.Map<IEnumerable<Supervisor>, IEnumerable<SupervisorDTO>>(supervisors);
        }

        public void Create(SupervisorDTO supervisor)
        {
            throw new NotImplementedException();
        }

        public void Update(SupervisorDTO supervisor)
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
