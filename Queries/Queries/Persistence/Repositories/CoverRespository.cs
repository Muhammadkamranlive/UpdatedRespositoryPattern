using Queries.Core.Domain;
using Queries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Persistence.Repositories
{
    public class CoverRespository: Repository<Cover> ,ICoverRepository
    {
        public CoverRespository(LearningContext context):base(context)
        {

        }
    }
}
