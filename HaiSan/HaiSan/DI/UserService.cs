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
        private async Task<List<GioHangModel>> GetGioHangByStatusAsync(string userid, short status)
        {
            var gioHang = _context.Giohangs.Where(e => e.Username == userid && e.Status == status).ToList();
            List<GioHangModel> res = new List<GioHangModel>();
            foreach (var e in gioHang)
            {
                var gioHangView = new GioHangModel()
                {
                    IdGioHang = e.IdGioHang,
                    CardHolder = e.CardHolder,
                    CardNumber = e.CardNumber,
                    DateCreated = e.DateCreated,
                    DateUpdated = e.DateUpdated,
                    Location = e.Location,
                    Phone = e.Phone,
                    Status = e.Status,
                    Watched = e.Watched,
                };
                var item = _context.Items.Where(x => x.IdGioHang == e.IdGioHang).ToList();
                List<CartItem> listCartItem = new List<CartItem>();
                foreach (var i in item)
                {
                    var sp = await _context.Sanphams.FindAsync(i.MaSp);
                    var cartItem = new CartItem()
                    {
                        MaSP = sp,
                        Sl = i.SoluongMua
                    };
                    listCartItem.Add(cartItem);
                }
                gioHangView.Products = listCartItem;
                res.Add(gioHangView);
            }
            return res;
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

        public async Task<List<GioHangModel>> GetAllProductsByActionAsync(string userid, short action)
        {
            return await GetGioHangByStatusAsync(userid, action);
        }
    }
}
