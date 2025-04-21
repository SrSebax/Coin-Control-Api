using CoinControl.Api.Data;
using CoinControl.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoinControl.Api.Services
{
    public class UserService
    {
        private readonly CoinControlDbContext _context;

        public UserService(CoinControlDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserIfNotExistsAsync(AuthModel model)
        {
            // Verifica si el usuario ya existe
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Uid == model.Uid);
            if (existingUser != null)
            {
                return existingUser;
            }

            // Crea nuevo usuario
            var newUser = new User
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
