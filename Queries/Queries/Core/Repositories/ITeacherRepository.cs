using Queries.Core.Domain;

namespace Queries.Core.Repositories
{
    public interface ITeacherRepository : IRepository<Teachers>
    {
        Teachers GetAuthorWithCourses(int id);
    }
}