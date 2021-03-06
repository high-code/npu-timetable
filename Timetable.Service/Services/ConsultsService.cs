﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.Interfaces;
using Timetable.Service.DTO;
using Timetable.DAL.Specifications;
using AutoMapper;

namespace Timetable.Service.Services
{
    public class ConsultsService : IConsultsService
    {
        private readonly IConsultRepository consultRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly DateTime nullDateTime = DateTime.MinValue;

        public ConsultsService(IConsultRepository consultRepo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.consultRepository = consultRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int Count
        {
            get { return Count; }
        }

        public ConsultDTO Get(int id)
        {
            var consult = consultRepository.GetById(id);

            return mapper.Map<Consult, ConsultDTO>(consult);
        }


        public IEnumerable<ConsultDTO> GetAll()
        {
            var consults = consultRepository.GetAll();

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> Filter(DateTime? date, string facultyTitle, string subjectName,
            string classroomTitle, string academicGroupName)
        {
            ConsultSpecification consultSpecification = new ConsultSpecification(date, facultyTitle,
                subjectName, classroomTitle, academicGroupName);
            

            var consults = consultRepository.GetMany(consultSpecification);


            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);

        }

        public void Create(ConsultDTO consult)
        {
            throw new NotImplementedException();
        }

        public void Update(ConsultDTO consult)
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
