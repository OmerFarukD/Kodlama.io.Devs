using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Contexts;

namespace Devs.Persistence.Repositories
{
    public class FrameworkRepository : EfRepositoryBase<Framework,BaseDbContext>,IFrameworkRepository
    {
        public FrameworkRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
