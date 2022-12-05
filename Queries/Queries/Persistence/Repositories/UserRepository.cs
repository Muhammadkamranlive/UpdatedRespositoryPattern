using Queries.Core.Domain;
using Queries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Persistence.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(LearningContext context):base(context)
        {

        }
    }
}
