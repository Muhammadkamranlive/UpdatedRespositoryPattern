using Queries.Core.Domain;
using Queries.Persistence.EntityConfigurations;
using System.Data.Entity;
using System.Reflection.Emit;

namespace Queries.Persistence
{
    public class LearningContext : DbContext
    {
        public LearningContext()
            : base("name=LearningContext")
        {
            // Avoid lazy loading  in web.
           // this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Student>Students { get; set; } 
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cover> Covers{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
         
            
        
    }
    }
}
