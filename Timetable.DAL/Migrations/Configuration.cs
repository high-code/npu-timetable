namespace Timetable.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Timetable.DAL.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Timetable.DAL.TimetableContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Timetable.DAL.TimetableContext context)
        {
            context.Faculties.AddOrUpdate(x => x.FacultyId,
                new Faculty() { FacultyId = 1, FacultyName = "��������� �����������" });

            context.Specialties.AddOrUpdate(x => x.SpecialtyId,
                new Specialty() { SpecialtyId = 1, SpecialtyTitle = "��������� ��������", SpecialtyCode = "6.050103", SpecialtyAbbreviation = "ϲ" });

            context.AcademicGroups.AddOrUpdate(x => x.AcademicGroupId,
                new AcademicGroup()
                {
                    AcademicGroupId = 1,
                    GroupName = "31ϲ",
                    CreationDate = new DateTime(2015, 9, 1),
                    FacultyId = 1,
                    Course = 3,
                    StudentsAmount = 12,
                    SpecialtyId = 1
                });

            context.Buildings.AddOrUpdate(x => x.BuildingId,
                new Building() { BuildingId = 1, BuildingAddress = "������ ��������, 9", BuildingTitle = "����������� ������" });

            context.Classrooms.AddOrUpdate(x => x.ClassroomId,
                new Classroom() { ClassroomId = 1, BuildingId = 1, ClassroomTitle = "229a" });

            context.Chairs.AddOrUpdate(x => x.ChairId);

            context.Chairs.AddOrUpdate(x => x.ChairId, new Chair()
            {
                ChairId = 1,
                ChairTitle = "������� ��������� �������",
                FacultyId = 1,
                Teachers = new List<Teacher>
                {
                    new Teacher() {
                        UserId = 1,
                        UserName = "selinum",
                        FirstName = "���",
                        FathersName = "����������",
                        LastName = "����"
                    }

                }
            });



            context.SubjectTypes.AddOrUpdate(x => x.SubjectTypeId,
                new SubjectType() { SubjectTypeId = 1, SubjectTypeTitle = "������" });

            context.Subjects.AddOrUpdate(x => x.SubjectId,
                new Subject()
                {
                    SubjectId = 1,
                    ChairId = 1,
                    SubjectTitle = "����������� ����������� ������������",
                    SubjectTypeId = 1,
                    TeacherId = 1
                });

            context.Lessons.AddOrUpdate(x => x.Id,
                new Lesson()
                {
                    Id = 1,
                    AcademicGroupId = 1,
                    ClassroomId = 1,
                    ExpectedAmountOfStudents = 12,
                    FacultyId = 1,
                    IsEnumerator = false,
                    LessonOrder = 4,
                    SubjectId = 1,
                    Weekday = 4,
                    TeacherNotification = ""
                });

            context.Consults.AddOrUpdate(x => x.Id,
                new Consult()
                {
                    Id = 1,
                    AcademicGroupId = 1,
                    ClassroomId = 1,
                    Date = new DateTime(2018, 1, 15),
                    FacultyId = 1,
                    SubjectId = 1                
                });

            context.Exams.AddOrUpdate(x => x.Id,
                new Exam()
                {
                    Id = 1,
                    AcademicGroupId = 1,
                    ClassroomId = 1,
                    Date = new DateTime(2018, 1, 16),
                    FacultyId = 1,
                    SubjectId = 1
                });

        }
    }
}
