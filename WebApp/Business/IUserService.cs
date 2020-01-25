using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Business
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        Task<User> GetAllowedUser(string username);

        IEnumerable<Role> GetRoles();
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.AsEnumerable();
        }

        public async Task<User> GetAllowedUser(string username)
        {
            return await _context.Users.Where(q => q.Username == username)
                .Include(i => i.Roles).ThenInclude(i => i.Role)
                .SingleOrDefaultAsync();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _context.Roles.AsEnumerable();
        }
    }
}