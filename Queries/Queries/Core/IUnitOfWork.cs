using Queries.Core.Repositories;
using System;

namespace Queries.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        ITeacherRepository Teachers { get; }
        ICategoryRepository Category { get; }
        ICoverRepository Cover { get; }
        IStudentRepository Student { get; }
        IUserRepository User { get; }
        int Save();
    }
}