using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject;
using AutoMapper;
using AutoMapper.Configuration;
using Timetable.DAL.Entities;
using Timetable.Service.DTO;
namespace Timetable.Service.Infrastructure
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }


        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));

                // Your mappings go here
                config.CreateMap<AcademicGroup, AcademicGroupDTO>();
                config.CreateMap<Building, BuildingDTO>();
                config.CreateMap<Chair, ChairDTO>()
                    .ForMember(dest => dest.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName));
                config.CreateMap<Classroom, ClassroomDTO>()
                    .ForMember(dest => dest.BuildingTitle, opt => opt.MapFrom(src => src.Building.BuildingTitle));

                config.CreateMap<Consult, ConsultDTO>()
                    .ForMember(dest => dest.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName))
                    .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectTitle))
                    .ForMember(dest => dest.ClassroomTitle, opt => opt.MapFrom(src => src.Classroom.ClassroomTitle))
                    .ForMember(dest => dest.AcademicGroupName, opt => opt.MapFrom(src => src.AcademicGroup.GroupName));

                //config.CreateMap<Exam, ExamDTO>()
                //    .ForMember(dest => dest.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName))
                //    .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectTitle))
                //    .ForMember(dest => dest.ClassroomTitle, opt => opt.MapFrom(src => src.Classroom.ClassroomTitle))
                //    .ForMember(dest => dest.AcademicGroupName, opt => opt.MapFrom(src => src.AcademicGroup.GroupName));
                //config.CreateMap<Faculty, FacultyDTO>();

                //config.CreateMap<Lesson, LessonDetailsDTO>()
                //    .ForMember(dest => dest.AcademicGroupName, opt => opt.MapFrom(src => src.AcademicGroup.GroupName))
                //    .ForMember(dest => dest.BuildingTitle, opt => opt.MapFrom(src => src.Classroom.Building.BuildingTitle))
                //    .ForMember(dest => dest.ClassroomTitle, opt => opt.MapFrom(src => src.Classroom.ClassroomTitle))
                //    .ForMember(dest => dest.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName))
                //    .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectTitle))
                //    .ForMember(dest => dest.SubjectTypeName, opt => opt.MapFrom(src => src.Subject.SubjectType.SubjectTypeTitle));
                //config.CreateMap<Specialty, SpecialtyDTO>();
                //config.CreateMap<Student, StudentDTO>()
                //    .ForMember(dest => dest.AcademicGroupName, opt => opt.MapFrom(src => src.AcademicGroup.GroupName))
                //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LastName + " " + src.FirstName + " " + src.FathersName));
                //config.CreateMap<Subject, SubjectDTO>()
                //    .ForMember(dest => dest.ChairTitle, opt => opt.MapFrom(src => src.Chair.ChairTitle))
                //    .ForMember(dest => dest.SubjectTypeName, opt => opt.MapFrom(src => src.SubjectType.SubjectTypeTitle))
                //    .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.LastName
                //        + " " + src.Teacher.FirstName + " " + src.Teacher.FathersName));
                //config.CreateMap<SubjectType, SubjectTypeDTO>();
                //config.CreateMap<Supervisor, SupervisorDTO>()
                //    .ForMember(dest => dest.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName))
                //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LastName + " "
                //        + src.FirstName + " " + src.FathersName));

                //config.CreateMap<Teacher, TeacherDTO>()
                //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LastName + " "
                //        + src.FirstName + " " + src.FathersName));
                    
                
            });

            Mapper.AssertConfigurationIsValid();
            return Mapper.Instance;
        }
            
    }
    
}  
