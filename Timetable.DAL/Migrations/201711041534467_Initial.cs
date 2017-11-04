namespace Timetable.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicGroups",
                c => new
                    {
                        AcademicGroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Course = c.Int(nullable: false),
                        StudentsAmount = c.Int(nullable: false),
                        SpecialtyId = c.Int(nullable: false),
                        FacultyId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AcademicGroupId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId, cascadeDelete: true)
                .Index(t => t.SpecialtyId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Consults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyId = c.Int(),
                        SubjectId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                        AcademicGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicGroups", t => t.AcademicGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .Index(t => t.FacultyId)
                .Index(t => t.SubjectId)
                .Index(t => t.ClassroomId)
                .Index(t => t.AcademicGroupId);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomId = c.Int(nullable: false, identity: true),
                        ClassroomTitle = c.String(),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassroomId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingTitle = c.String(),
                        BuildingAddress = c.String(),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyId = c.Int(),
                        SubjectId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                        AcademicGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicGroups", t => t.AcademicGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .Index(t => t.FacultyId)
                .Index(t => t.SubjectId)
                .Index(t => t.ClassroomId)
                .Index(t => t.AcademicGroupId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        ChairId = c.Int(nullable: false, identity: true),
                        ChairTitle = c.String(),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChairId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FathersName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectTitle = c.String(),
                        SubjectTypeId = c.Int(nullable: false),
                        ChairId = c.Int(),
                        TeacherId = c.Int(nullable: false),
                        Teacher_UserId = c.Int(),
                        Faculty_FacultyId = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Chairs", t => t.ChairId)
                .ForeignKey("dbo.SubjectTypes", t => t.SubjectTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_UserId)
                .ForeignKey("dbo.Faculties", t => t.Faculty_FacultyId)
                .Index(t => t.SubjectTypeId)
                .Index(t => t.ChairId)
                .Index(t => t.Teacher_UserId)
                .Index(t => t.Faculty_FacultyId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyId = c.Int(),
                        SubjectId = c.Int(nullable: false),
                        LessonOrder = c.Int(nullable: false),
                        AcademicGroupId = c.Int(),
                        Weekday = c.Int(nullable: false),
                        ClassroomId = c.Int(),
                        IsEnumerator = c.Boolean(nullable: false),
                        ExpectedAmountOfStudents = c.Int(nullable: false),
                        TeacherNotification = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicGroups", t => t.AcademicGroupId)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.FacultyId)
                .Index(t => t.SubjectId)
                .Index(t => t.AcademicGroupId)
                .Index(t => t.ClassroomId);
            
            CreateTable(
                "dbo.SubjectTypes",
                c => new
                    {
                        SubjectTypeId = c.Int(nullable: false, identity: true),
                        SubjectTypeTitle = c.String(),
                    })
                .PrimaryKey(t => t.SubjectTypeId);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        SpecialtyId = c.Int(nullable: false, identity: true),
                        SpecialtyCode = c.String(),
                        SpecialtyTitle = c.String(),
                        SpecialtyAbbreviation = c.String(),
                        Specialty_SpecialtyId = c.Int(),
                    })
                .PrimaryKey(t => t.SpecialtyId)
                .ForeignKey("dbo.Specialties", t => t.Specialty_SpecialtyId)
                .Index(t => t.Specialty_SpecialtyId);
            
            CreateTable(
                "dbo.TeacherChairs",
                c => new
                    {
                        Teacher_UserId = c.Int(nullable: false),
                        Chair_ChairId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_UserId, t.Chair_ChairId })
                .ForeignKey("dbo.Teachers", t => t.Teacher_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Chairs", t => t.Chair_ChairId, cascadeDelete: true)
                .Index(t => t.Teacher_UserId)
                .Index(t => t.Chair_ChairId);
            
            CreateTable(
                "dbo.SpecialtyFaculties",
                c => new
                    {
                        Specialty_SpecialtyId = c.Int(nullable: false),
                        Faculty_FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Specialty_SpecialtyId, t.Faculty_FacultyId })
                .ForeignKey("dbo.Specialties", t => t.Specialty_SpecialtyId, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.Faculty_FacultyId, cascadeDelete: true)
                .Index(t => t.Specialty_SpecialtyId)
                .Index(t => t.Faculty_FacultyId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FathersName = c.String(),
                        AcademicGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AcademicGroups", t => t.AcademicGroupId, cascadeDelete: true)
                .Index(t => t.AcademicGroupId);
            
            CreateTable(
                "dbo.Supervisors",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FathersName = c.String(),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FathersName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supervisors", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Students", "AcademicGroupId", "dbo.AcademicGroups");
            DropForeignKey("dbo.AcademicGroups", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Subjects", "Faculty_FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Specialties", "Specialty_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.SpecialtyFaculties", "Faculty_FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.SpecialtyFaculties", "Specialty_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Exams", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Consults", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Subjects", "Teacher_UserId", "dbo.Teachers");
            DropForeignKey("dbo.Subjects", "SubjectTypeId", "dbo.SubjectTypes");
            DropForeignKey("dbo.Lessons", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Lessons", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Lessons", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Lessons", "AcademicGroupId", "dbo.AcademicGroups");
            DropForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Consults", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "ChairId", "dbo.Chairs");
            DropForeignKey("dbo.TeacherChairs", "Chair_ChairId", "dbo.Chairs");
            DropForeignKey("dbo.TeacherChairs", "Teacher_UserId", "dbo.Teachers");
            DropForeignKey("dbo.Chairs", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.AcademicGroups", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Exams", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Exams", "AcademicGroupId", "dbo.AcademicGroups");
            DropForeignKey("dbo.Consults", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Classrooms", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Consults", "AcademicGroupId", "dbo.AcademicGroups");
            DropIndex("dbo.Supervisors", new[] { "FacultyId" });
            DropIndex("dbo.Students", new[] { "AcademicGroupId" });
            DropIndex("dbo.SpecialtyFaculties", new[] { "Faculty_FacultyId" });
            DropIndex("dbo.SpecialtyFaculties", new[] { "Specialty_SpecialtyId" });
            DropIndex("dbo.TeacherChairs", new[] { "Chair_ChairId" });
            DropIndex("dbo.TeacherChairs", new[] { "Teacher_UserId" });
            DropIndex("dbo.Specialties", new[] { "Specialty_SpecialtyId" });
            DropIndex("dbo.Lessons", new[] { "ClassroomId" });
            DropIndex("dbo.Lessons", new[] { "AcademicGroupId" });
            DropIndex("dbo.Lessons", new[] { "SubjectId" });
            DropIndex("dbo.Lessons", new[] { "FacultyId" });
            DropIndex("dbo.Subjects", new[] { "Faculty_FacultyId" });
            DropIndex("dbo.Subjects", new[] { "Teacher_UserId" });
            DropIndex("dbo.Subjects", new[] { "ChairId" });
            DropIndex("dbo.Subjects", new[] { "SubjectTypeId" });
            DropIndex("dbo.Chairs", new[] { "FacultyId" });
            DropIndex("dbo.Exams", new[] { "AcademicGroupId" });
            DropIndex("dbo.Exams", new[] { "ClassroomId" });
            DropIndex("dbo.Exams", new[] { "SubjectId" });
            DropIndex("dbo.Exams", new[] { "FacultyId" });
            DropIndex("dbo.Classrooms", new[] { "BuildingId" });
            DropIndex("dbo.Consults", new[] { "AcademicGroupId" });
            DropIndex("dbo.Consults", new[] { "ClassroomId" });
            DropIndex("dbo.Consults", new[] { "SubjectId" });
            DropIndex("dbo.Consults", new[] { "FacultyId" });
            DropIndex("dbo.AcademicGroups", new[] { "FacultyId" });
            DropIndex("dbo.AcademicGroups", new[] { "SpecialtyId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Supervisors");
            DropTable("dbo.Students");
            DropTable("dbo.SpecialtyFaculties");
            DropTable("dbo.TeacherChairs");
            DropTable("dbo.Specialties");
            DropTable("dbo.SubjectTypes");
            DropTable("dbo.Lessons");
            DropTable("dbo.Subjects");
            DropTable("dbo.Users");
            DropTable("dbo.Chairs");
            DropTable("dbo.Faculties");
            DropTable("dbo.Exams");
            DropTable("dbo.Buildings");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Consults");
            DropTable("dbo.AcademicGroups");
        }
    }
}
