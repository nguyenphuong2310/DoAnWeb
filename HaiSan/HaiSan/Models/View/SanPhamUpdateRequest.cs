using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Models.View
{
    public class SanPhamUpdateRequest
    {
        public string MaSp { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Ten { get; set; }
        [Display(Name = "Giá bán")]
        [Required]
        public decimal Gia { get; set; }
        [Display(Name = "Số lượng")]
        [Required]
        public int Soluong { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        [Required]
        public string MoTa { get; set; }
        [Display(Name = "Hình nền(có thể bỏ qua nếu không thay đổi hình nền)")]
        public IFormFile Img { get; set; }
        [Display(Name = "Loại size")]
        public string IdSize { get; set; }
        [Display(Name = "Loại hàng")]
        [Required(ErrorMessage = "Chọn 1 loại sản phẩm")]
        public string MaLoai { get; set; }
        public string Username { get; set; }
    }
}
