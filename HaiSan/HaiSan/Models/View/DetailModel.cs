using HaiSan.Models.Pure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Models.View
{
    public class DetailModel
    {
        public Sanpham SanPham { get; set; }
        public List<Sanpham> RelateProd { get; set; }
    }
}
