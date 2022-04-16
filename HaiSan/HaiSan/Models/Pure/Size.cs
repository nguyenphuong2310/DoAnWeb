using System;
using System.Collections.Generic;

#nullable disable

namespace HaiSan.Models.Pure
{
    public partial class Size
    {
        public Size()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string IdSize { get; set; }
        public string Size1 { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
