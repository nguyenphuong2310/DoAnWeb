using System;
using System.Collections.Generic;

#nullable disable

namespace HaiSan.Models.Pure
{
    public partial class Loaisp
    {
        public Loaisp()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string Maloai { get; set; }
        public string TenLoai { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
