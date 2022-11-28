using Queries.Core.Domain;
using Queries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>,IStudentRepository
    {
        public StudentRepository(LearningContext context):base(context)
        {

        }
    }
}
