using Queries.Core.Domain;
using System.Collections.Generic;

namespace Queries.Core.Domain
{
    public class Teachers
    {
        public Teachers()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
