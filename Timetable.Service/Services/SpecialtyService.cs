using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.Service.Interfaces;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.Service.DTO;
using AutoMapper;
namespace Timetable.Service.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        ISpecialtyRepository specialtyRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public SpecialtyService(ISpecialtyRepository specialtyRepo,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.specialtyRepository = specialtyRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public SpecialtyDTO Get(int specialtyId)
        {
            var specialtyDTO = specialtyRepository.GetById(specialtyId);

            return mapper.Map<Specialty, SpecialtyDTO>(specialtyDTO);
        }

        public IEnumerable<SpecialtyDTO> GetAll()
        {
            var specialties = specialtyRepository.GetAll();

            return mapper.Map<IEnumerable<Specialty>, IEnumerable<SpecialtyDTO>>(specialties);
        }

        public SpecialtyDTO GetSpecialtyByAbbreviation(string abbreviation)
        {
            var specialty = specialtyRepository.GetSpecialtyByAbbreviation(abbreviation);

            return mapper.Map<Specialty, SpecialtyDTO>(specialty);
        }

        public SpecialtyDTO GetSpecialtyByCode(string code)
        {
            var specialty = specialtyRepository.GetSpecialtyByCode(code);

            return mapper.Map<Specialty, SpecialtyDTO>(specialty);
        }

        public SpecialtyDTO GetSpecialtyByTitle(string title)
        {
            var specialty = specialtyRepository.GetSpecialtyByTitle(title);

            return mapper.Map<Specialty, SpecialtyDTO>(specialty);
        }

        public void Create(SpecialtyDTO specialtyDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(SpecialtyDTO specialtyDTO)
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
