using System;
using System.Collections.Generic;

#nullable disable

namespace HaiSan.Models.Pure
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Giohangs = new HashSet<Giohang>();
            Sanphams = new HashSet<Sanpham>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Ten { get; set; }
        public string Phone { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Giohang> Giohangs { get; set; }
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
