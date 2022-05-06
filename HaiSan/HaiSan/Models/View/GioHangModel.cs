using HaiSan.Models.Pure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Models.View
{
    public class GioHangModel
    {
        public string IdGioHang { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public bool? Watched { get; set; }
        public short? Status { get; set; }
        public List<CartItem> Products { get; set; }
        public void toGioHangModel(Giohang gh)
        {
            this.IdGioHang = gh.IdGioHang;
            this.DateCreated = gh.DateCreated;
            this.Location = gh.Location;
            this.Phone = gh.Phone;
            this.Status = gh.Status;
        }
    }
}
