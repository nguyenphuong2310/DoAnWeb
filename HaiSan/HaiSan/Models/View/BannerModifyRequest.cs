using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Models.View
{
    public class BannerModifyRequest
    {
        [Required]
        public int SlideIndex { get; set; }
        [Required]
        public string Title { get; set; }

        public IFormFile Img { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
