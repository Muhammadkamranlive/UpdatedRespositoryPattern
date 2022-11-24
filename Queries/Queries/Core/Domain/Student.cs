using Queries.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Core.Domain
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Teachers> Authors { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
