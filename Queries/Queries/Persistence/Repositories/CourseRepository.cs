using Queries.Core.Domain;
using Queries.Core.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Queries.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository   
    {
        public CourseRepository(LearningContext context) 
            : base(context)
        {
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return CourseContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return CourseContext.Courses
                .Include(c => c.Teacher)
                .OrderBy(c => c.CourseTitle)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        

        public LearningContext CourseContext
        {
            get { return Context as LearningContext; }
        }
    }
}