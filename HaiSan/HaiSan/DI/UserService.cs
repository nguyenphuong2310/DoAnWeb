using HaiSan.Models.Pure;
using HaiSan.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace HaiSan.DI
{
    public class UserService : IUserService
    {

        private readonly HaiSanContext _context;
        public UserService(HaiSanContext context)
        {
            _context = context;
        }

        public List<Sanpham> GetAllProductByUsername(string id)
        {
            var prods = _context.Sanphams.Where(e => e.Username == id).ToList();
            return prods;
        }

        public async Task<User> GetUserByUserName(string username)
        {
            var user = await _context.Users.FindAsync(username);
            return user;
        }

        public User Login(LoginModel request)
        {
            var user = _context.Users.SingleOrDefault(e => e.Username == request.Username);
            if (user == null || !BC.Verify(request.Password, user.Password))
            {
                return null;
            }
            return user;
        }

        public async Task<int> Register(RegisterModel user)
        {
            User newMember = new User()
            {
                Username = user.Username,
                Ten = user.Name,
                Phone = user.Phone,
                RoleId = "member",
            };

            newMember.Password = BC.HashPassword(user.Password);
            await _context.Users.AddAsync(newMember);
            return await _context.SaveChangesAsync();
        }

        public Task<List<Sanpham>> Search(string key, string id)
        {
            throw new NotImplementedException();
        }
    }
}
