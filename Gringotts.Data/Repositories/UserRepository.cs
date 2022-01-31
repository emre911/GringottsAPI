using Gringotts.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gringotts.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IGringottsDataContext _context;
        public UserRepository(IGringottsDataContext context)
        {
            _context = context;
        }
        
        public async Task<User> Get(string userName)
        {
            return await _context.User.Where(c => c.Username == userName).FirstOrDefaultAsync();
        }  
    }
}
