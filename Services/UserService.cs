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

        public List<UserModel> GetUsers()
        {
            return _context.Users.ToList();
        }

        // Obtener un usuario por UID
        public async Task<UserModel?> GetUserByUidAsync(string uid)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Uid == uid);
        }

        // Actualizar un usuario por UID
        public async Task<UserModel?> UpdateUserAsync(string uid, UserModel userModel)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Uid == uid);
            if (existingUser == null) return null;

            // Actualiza los campos del usuario
            existingUser.Uid = userModel.Uid ?? existingUser.Uid;
            existingUser.Name = userModel.Name ?? existingUser.Name;
            existingUser.Email = userModel.Email ?? existingUser.Email;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        // Eliminar un usuario por UID
        public async Task<bool> DeleteUserAsync(string uid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Uid == uid);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
