using HaiSan.DI;
using HaiSan.Models.Pure;
using HaiSan.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _service;
        public CartController(IProductService service)
        {
            _service = service;
        }
        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";
        public IActionResult Index()
        {
            return View(GetCartItems());
        }
        // Lấy cart từ Session (danh sách CartItem)
        [Route("/cart/session")]
        public List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        /// Thêm sản phẩm vào cart
        [Route("/cart/addtocart")]
        [HttpPost]
        public async Task<bool> AddToCart([FromBody] ItemAjjax i)
        {

            var product = await _service.GetById(i.MaSp);
            if (product == null)
                return false;

            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.MaSP.MaSp == i.MaSp);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.Sl += i.Sl;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() { Sl = i.Sl, MaSP = product });
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return true;
        }
        [Route("/cart/remove")]
        [HttpPost]
        public List<CartItem> RemoveToCart([FromBody] ItemAjjax i)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.MaSP.MaSp == i.MaSp);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
                SaveCartSession(cart);
            }
            return cart.Count == 0 ? null : cart;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BuyAsync(BuyModel request)
        {
            Giohang gh = new Giohang()
            {
                IdGioHang = Guid.NewGuid().ToString(),
                DateCreated = DateTime.Now,
                Location = request.Location,
                Phone = request.Phone,
                Status = 0,
                Username = User.Identity.Name,
                Watched = false,
            };
            List<Item> items = new List<Item>();
            foreach (var e in GetCartItems())
            {
                Item i = new Item()
                {
                    DateCreated = DateTime.Now,
                    GiamGia = 0,
                    IdGioHang = gh.IdGioHang,
                    MaSp = e.MaSP.MaSp,
                    SoluongMua = e.Sl
                };
                items.Add(i);
            }
            var res = await _service.Buy(gh, items);
            if(res != 0)
                return RedirectToAction("pending", "user");
            return View();
        }
        [Route("/cart/removeItem")]
        [HttpPost]
        public async Task<bool> RemoveItemAsync([FromBody]ItemGioHang request)
        {
            var gh = await _service.GetGioHang(request.Id);
            if (gh.Status > 1) return false;
            var res = await _service.RemoveItem(request);
            return res != 0;
        }

        [Route("/cart/removeGioHang")]
        [HttpPost]
        public async Task<bool> RemoveGioHang([FromBody] IdRequest request)
        {
            var gh = await _service.GetGioHang(request.Id);
            if (gh.Status > 1) return false;
            return await _service.RemoveGioHang(request.Id) != 0;
        }


    }
}
