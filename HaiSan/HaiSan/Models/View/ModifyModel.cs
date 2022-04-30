using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Models.View
{
    public class ModifyModel
    {
        public BannerModifyRequest Banner { get; set; }
        public CategoryModifyRequest Category { get; set; }
        public ProductsModifyRequest Products { get; set; }
    }
}
