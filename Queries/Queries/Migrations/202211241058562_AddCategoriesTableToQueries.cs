namespace Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTableToQueries : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Teachers", newName: "Teachers");
            RenameTable(name: "dbo.StudentAuthors", newName: "StudentTeachers");
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Teachers");
            RenameColumn(table: "dbo.StudentTeachers", name: "Author_Id", newName: "Teachers_Id");
            RenameIndex(table: "dbo.StudentTeachers", name: "IX_Author_Id", newName: "IX_Teachers_Id");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "Category_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropColumn("dbo.Courses", "Category_Id");
            DropTable("dbo.Categories");
            RenameIndex(table: "dbo.StudentTeachers", name: "IX_Teachers_Id", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.StudentTeachers", name: "Teachers_Id", newName: "Author_Id");
            AddForeignKey("dbo.Courses", "AuthorId", "dbo.Teachers", "Id");
            RenameTable(name: "dbo.StudentTeachers", newName: "StudentAuthors");
            RenameTable(name: "dbo.Teachers", newName: "Teachers");
        }
    }
}
