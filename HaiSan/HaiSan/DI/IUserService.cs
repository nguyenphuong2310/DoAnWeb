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
        List<Sanpham> GetAllProductByUsername(string id);
        Task<List<Sanpham>> Search(string key, string id);
    }
}
