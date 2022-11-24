namespace Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorTableToStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Author_Id", "dbo.Teachers");
            DropIndex("dbo.Students", new[] { "Author_Id" });
            CreateTable(
                "dbo.StudentAuthors",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Author_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Author_Id);
            
            DropColumn("dbo.Students", "Author_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Author_Id", c => c.Int());
            DropForeignKey("dbo.StudentAuthors", "Author_Id", "dbo.Teachers");
            DropForeignKey("dbo.StudentAuthors", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentAuthors", new[] { "Author_Id" });
            DropIndex("dbo.StudentAuthors", new[] { "Student_Id" });
            DropTable("dbo.StudentAuthors");
            CreateIndex("dbo.Students", "Author_Id");
            AddForeignKey("dbo.Students", "Author_Id", "dbo.Teachers", "Id");
        }
    }
}
