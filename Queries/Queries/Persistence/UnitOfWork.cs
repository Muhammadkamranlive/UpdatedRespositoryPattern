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
            Category = new CategoryRepository(_context);
            Cover = new CoverRespository(_context);
            Student = new StudentRepository(_context); 
            User =  new UserRepository(_context);
        }


        public ICourseRepository Courses { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public ICoverRepository Cover { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IStudentRepository Student { get; private set; }
        public IUserRepository User { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}