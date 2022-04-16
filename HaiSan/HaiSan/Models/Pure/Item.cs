using System;
using System.Collections.Generic;

#nullable disable

namespace HaiSan.Models.Pure
{
    public partial class Item
    {
        public string MaSp { get; set; }
        public string IdGioHang { get; set; }
        public int? SoluongMua { get; set; }
        public decimal? GiamGia { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Giohang IdGioHangNavigation { get; set; }
        public virtual Sanpham MaSpNavigation { get; set; }
    }
}
