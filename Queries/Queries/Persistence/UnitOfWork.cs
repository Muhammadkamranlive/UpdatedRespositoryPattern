using Queries.Core;
using Queries.Core.Repositories;
using Queries.Persistence.Repositories;

namespace Queries.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LearningContext _context;

        public UnitOfWork(LearningContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Teachers = new TeacherRepository(_context);
        }

        public ICourseRepository Courses { get; private set; }
        public ITeacherRepository Teachers { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}