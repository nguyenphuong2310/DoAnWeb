using System;
using System.Collections.Generic;

#nullable disable

namespace HaiSan.Models.Pure
{
    public partial class Giohang
    {
        public Giohang()
        {
            Items = new HashSet<Item>();
        }

        public string IdGioHang { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string Expired { get; set; }
        public string Cvv { get; set; }
        public bool? Watched { get; set; }
        public short? Status { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
