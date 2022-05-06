using System;
using System.Collections.Generic;

#nullable disable

namespace HaiSan.Models.Pure
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Comments = new HashSet<Comment>();
            Items = new HashSet<Item>();
        }

        public string MaSp { get; set; }
        public string Ten { get; set; }
        public decimal Gia { get; set; }
        public int? Soluong { get; set; }
        public string Title { get; set; }
        public string MoTa { get; set; }
        public string Img { get; set; }
        public DateTime? DateCreated { get; set; }
        public string IdSize { get; set; }
        public string MaLoai { get; set; }
        public string Username { get; set; }

        public virtual Size IdSizeNavigation { get; set; }
        public virtual Loaisp MaLoaiNavigation { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
