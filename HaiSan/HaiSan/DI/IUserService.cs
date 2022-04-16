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
        User Login(LoginModel request);
        Task<int> Register(RegisterModel user);
    }
}
