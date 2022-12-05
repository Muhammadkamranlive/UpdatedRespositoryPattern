using Queries.Core.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Queries.Core.Domain
{
    [Table("Teachers")]
    public class Teachers:User
    {
        public Teachers()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<Student>();
        }

      
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
