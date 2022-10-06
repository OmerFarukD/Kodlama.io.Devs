using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Devs.Domain.Entities;

namespace Devs.Application.Services.Repositories
{
    public interface IFrameworkRepository :IRepository<Framework>,IAsyncRepository<Framework>
    {
    }
}
