using HaiSan.Models.Pure;
using HaiSan.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.DI
{
    public interface IUserService
    {
        Task<User> GetUserByUserName(string username);
        User Login(LoginModel request);
        Task<int> Register(RegisterModel user);
        Task<List<GioHangModel>> GetAllProductsByActionAsync(string userid, short action);
        Task<List<Sanpham>> Search(string key, string id);
    }
}
