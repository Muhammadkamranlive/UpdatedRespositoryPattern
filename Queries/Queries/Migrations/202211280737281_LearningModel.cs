namespace Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LearningModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Level = c.Int(nullable: false),
                        FullPrice = c.Single(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Category_Id = c.Int(),
                        Cover_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Covers", t => t.Cover_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Cover_Id);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoverTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.TeachersCourses",
                c => new
                    {
                        Teachers_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teachers_Id, t.Course_Id })
                .ForeignKey("dbo.Teachers", t => t.Teachers_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Teachers_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.TeachersStudents",
                c => new
                    {
                        Teachers_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teachers_Id, t.Student_Id })
                .ForeignKey("dbo.Teachers", t => t.Teachers_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Teachers_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.TagId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.TeachersStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.TeachersStudents", "Teachers_Id", "dbo.Teachers");
            DropForeignKey("dbo.TeachersCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.TeachersCourses", "Teachers_Id", "dbo.Teachers");
            DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Courses", "Cover_Id", "dbo.Covers");
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CourseTags", new[] { "TagId" });
            DropIndex("dbo.CourseTags", new[] { "CourseId" });
            DropIndex("dbo.TeachersStudents", new[] { "Student_Id" });
            DropIndex("dbo.TeachersStudents", new[] { "Teachers_Id" });
            DropIndex("dbo.TeachersCourses", new[] { "Course_Id" });
            DropIndex("dbo.TeachersCourses", new[] { "Teachers_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            DropIndex("dbo.Courses", new[] { "Cover_Id" });
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropTable("dbo.CourseTags");
            DropTable("dbo.TeachersStudents");
            DropTable("dbo.TeachersCourses");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Tags");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Covers");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
