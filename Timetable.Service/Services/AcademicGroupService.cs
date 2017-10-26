using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.Interfaces;
using Timetable.Service.DTO;
using AutoMapper;

namespace Timetable.Service.Services
{
    
    public class AcademicGroupService: IAcademicGroupService
    {
        private readonly IAcademicGroupRepository academicGroupRepository;
        private readonly IFacultyRepository facultyRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AcademicGroupService(IAcademicGroupRepository academicGroupRepository, IFacultyRepository facultyRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.academicGroupRepository = academicGroupRepository;
            this.facultyRepository = facultyRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<AcademicGroupDTO> GetAll()
        {
            var academicGroups = academicGroupRepository.GetAll();
            
            return mapper.Map<IEnumerable<AcademicGroup>, List<AcademicGroupDTO>>(academicGroups);
        }

        public IEnumerable<AcademicGroupDTO> GetByFaculty(string facultyName)
        {
            

            if(string.IsNullOrEmpty(facultyName))
            {

                var academicGroups = academicGroupRepository.GetAcademicGroupsByFacultyName(facultyName);
                return mapper.Map<IEnumerable<AcademicGroup>, List<AcademicGroupDTO>>(academicGroups);
            }
            else
            {
                return this.GetAll();
            }
        }

        public IEnumerable<AcademicGroupDTO> GetByFacultyId(int id)
        {
            var academicGroups = academicGroupRepository.GetAcademicGroupsByFacultyId(id);

            return mapper.Map<IEnumerable<AcademicGroup>, IEnumerable<AcademicGroupDTO>>(academicGroups);

        }

        public IEnumerable<AcademicGroupDTO> GetBySpecialty(string specialty)
        {
            var academicGroups = academicGroupRepository.GetAcademicGroupBySpecialtyTitle(specialty);

            return mapper.Map<IEnumerable<AcademicGroup>, IEnumerable<AcademicGroupDTO>>(academicGroups);
        }

        public IEnumerable<AcademicGroupDTO> GetBySpecialtyId(int specialtyId)
        {
            var academicGroups = academicGroupRepository.GetAcademicGroupBySpecialtyId(specialtyId);

            return mapper.Map<IEnumerable<AcademicGroup>, IEnumerable<AcademicGroupDTO>>(academicGroups);
        }

        
        public IEnumerable<AcademicGroupDTO> Filter(string facultyTitle, string specialtyTitle)
        {
            var academicGroups = academicGroupRepository.GetMany(
                ag => facultyTitle == null || ag.Faculty.FacultyName.ToLower() == facultyTitle.ToLower()
                && specialtyTitle == null || ag.Specialty.SpecialtyTitle.ToLower() == specialtyTitle.ToLower());


            return mapper.Map<IEnumerable<AcademicGroup>, IEnumerable<AcademicGroupDTO>>(academicGroups);


        }

        public AcademicGroupDTO Get(int id)
        {
            
            var academicGroupDTO = academicGroupRepository.GetById(id);
            
            return mapper.Map<AcademicGroup, AcademicGroupDTO>(academicGroupDTO);
        }

        public AcademicGroupDTO Get(string name)
        {
            var academicGroup = academicGroupRepository.GetAcademicGroupByName(name);
            return mapper.Map<AcademicGroup, AcademicGroupDTO>(academicGroup);
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
