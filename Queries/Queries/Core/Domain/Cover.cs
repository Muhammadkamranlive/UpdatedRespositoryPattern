using System.Collections.Generic;

namespace Queries.Core.Domain
{
    public class Cover
    {
        public int Id { get; set; }
        public string CoverTitle { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
