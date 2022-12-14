using Queries.Core.Domain;
using Queries.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace Queries.Persistence.Repositories
{
    public class TeacherRepository : Repository<Teachers>, ITeacherRepository
    {
        public TeacherRepository(LearningContext context) : base(context)
        {
        }

        public Teachers GetAuthorWithCourses(int id)
        {
            return TeacherContext.Teachers.Include(a => a.Courses).SingleOrDefault(a => a.Id == id);
        }

        public LearningContext TeacherContext
        {
            get { return Context as LearningContext; }
        }
    }
}