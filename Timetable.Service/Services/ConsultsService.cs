using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.Interfaces;
using Timetable.Service.DTO;
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

        public ConsultDTO Get(int id)
        {
            var consult = consultRepository.GetById(id);

            return mapper.Map<Consult, ConsultDTO>(consult);
        }

        public IEnumerable<ConsultDTO> GetByFacultyTitle(string faculty)
        {
            var consults = consultRepository.GetConsultsByFaculty(faculty);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetByFacultyId(int facultyId)
        {
            var consults = consultRepository.GetConsultsByFacultyId(facultyId);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetByAcademicGroupName(string academicGroup)
        {
            var consults = consultRepository.GetConsultsByAcademicGroup(academicGroup);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetByAcademicGroupId(int academicGroupId)
        {
            var consults = consultRepository.GetConsultsByAcademicGroupId(academicGroupId);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetBySubjectTitle(string subject)
        {
            var consults = consultRepository.GetConsultsBySubject(subject);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetBySubjectId(int subjectId)
        {
            var consults = consultRepository.GetConsultsBySubjectId(subjectId);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetByClassroomTitle(string classroom)
        {
            var consults = consultRepository.GetConsultsByClassroom(classroom);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetByClassroomId(int classroomId)
        {
            var consults = consultRepository.GetConsultsByClassroomId(classroomId);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetByDate(DateTime date)
        {
            var consults = consultRepository.GetConsultsByDate(date);

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> GetAll()
        {
            var consults = consultRepository.GetAll();

            return mapper.Map<IEnumerable<Consult>, IEnumerable<ConsultDTO>>(consults);
        }

        public IEnumerable<ConsultDTO> Filter(DateTime? date, string facultyTitle, string subjectName,
            string classroomTitle, string academicGroupName)
        {
            var consults = consultRepository.GetMany(
                c =>  date == null || c.Date.Equals(date) &&
                      facultyTitle == null || c.Faculty.FacultyName.ToLower() == facultyTitle.ToLower() &&
                      subjectName == null || c.Subject.SubjectTitle.ToLower() == subjectName.ToLower() &&
                      classroomTitle == null || c.Classroom.ClassroomTitle.ToLower() == classroomTitle.ToLower() &&
                      academicGroupName == null || c.AcademicGroup.GroupName.ToLower() == academicGroupName.ToLower());


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
