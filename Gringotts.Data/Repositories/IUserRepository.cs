using Gringotts.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string userName);
    }
}
