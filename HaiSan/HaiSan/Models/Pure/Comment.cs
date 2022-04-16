using System;
using System.Collections.Generic;

#nullable disable

namespace HaiSan.Models.Pure
{
    public partial class Comment
    {
        public string IdComment { get; set; }
        public string Comment1 { get; set; }
        public DateTime? DateCreated { get; set; }
        public string MaSp { get; set; }
        public string Username { get; set; }

        public virtual Sanpham MaSpNavigation { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}
