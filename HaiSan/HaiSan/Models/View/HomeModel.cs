using HaiSan.Models.Pure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Models.View
{
    public class HomeModel
    {
        public List<Banner> Banner { get; set; }
        public List<Sanpham> FeatureProducts { get; set; }
        public List<Loaisp> FeatuteCategories { get; set; }
    }
}
