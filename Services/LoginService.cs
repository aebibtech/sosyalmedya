using jsonapisample.Data;
using jsonapisample.Models.Integration;
using Microsoft.EntityFrameworkCore;

namespace jsonapisample.Services
{
    public class LoginService(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> Login(LoginRequest creds)
        {
            if (creds == null)
                return false;

            Models.User? user = await _context.Users.Where(x => x.UserName == creds.Username).FirstOrDefaultAsync();
            if (user == null)
                return false;

            return user.Password.Equals(creds.Password);
        }
    }
}
