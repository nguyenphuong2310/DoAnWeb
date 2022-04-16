using HaiSan.Models.Pure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly HaiSanContext _context;
        public ProductController(ILogger<ProductController> logger, HaiSanContext context)
        {
            _logger = logger;
            _context = context;
        }
        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View(GetCartItems());
        }
        // Lấy cart từ Session (danh sách CartItem)
        List<Item> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<Item>>(jsoncart);
            }
            return new List<Item>();
        }
        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<Item> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        /// Thêm sản phẩm vào cart
        [Route("/products/addcart", Name = "addcart")]
        public bool AddToCart([FromBody] Item i)
        {

            var product = _context.Sanphams
                .Where(p => p.MaSp == i.MaSp)
                .FirstOrDefault();
            if (product == null)
                return false;

            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.MaSp == i.MaSp);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.SoluongMua += i.SoluongMua;
            }
            else
            {
                //  Thêm mới
                cart.Add(i);
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return true;
        }

    }
}
