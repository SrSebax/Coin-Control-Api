using CoinControl.Api.Data;
using CoinControl.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoinControl.Api.Services
{
    public class AuthService
    {
        private readonly CoinControlDbContext _context;

        public AuthService(CoinControlDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateUserIfNotExistsAsync(AuthModel model)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Uid == model.Uid);
            if (existingUser != null)
            {
                return existingUser;
            }

            var newUser = new UserModel
            {
                Uid = model.Uid,
                Name = model.Name,
                Email = model.Email
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
    }
}
