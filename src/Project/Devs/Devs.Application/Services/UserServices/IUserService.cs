using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;

namespace Devs.Application.Services.UserServices
{
    public interface IUserService
    {
        public Task<User?> GetByEmail(string email);
        public Task<User> GetById(int id);
        public Task<User> Update(User user);
    }
}
