using HaiSan.DI;
using HaiSan.Models.View;
using HaiSan.Ulti;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _service;

        public AdminController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> ChartAsync()
        {
            
            return View(await _service.GetMonthlyStatistics(2022));
        }
        public async Task<IActionResult> ModifyAsync()
        {
            ModifyInterface _interfaceService = new ModifyInterface(_service);
            var model = await _interfaceService.GetHomeModelAsync();
            ViewData["Info"] = model;
            return View();
        }
        public IActionResult Manager()
        {
            var userId = User.Identity.Name;
            return View(_service.GetAllProductByUsername(userId));
        }
        public IActionResult Carts()
        {
            return View(_service.GetAllGioHang());
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangeBanner(ModifyModel request)
        {
            if(ModelState.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin/banner.json");
                var o1 = JArray.Parse(System.IO.File.ReadAllText(@path));
                int index = request.Banner.SlideIndex;
                o1[index]["title"] = request.Banner.Title;
                o1[index]["content"] = request.Banner.Content;
                string fileName = null;
                if(request.Banner.Img != null)
                {
                    // Tạo unique name cho file
                    fileName = Guid.NewGuid() + Path.GetExtension(request.Banner.Img.FileName).ToLower();
                    // path
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", fileName);

                    // cái này để lưu thẳng từ IFormFile
                    // Lưu file vào wwwroot/assets/img folder
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await request.Banner.Img.CopyToAsync(stream);
                    }
                }
                if(fileName != null)
                {
                    o1[index]["path"] = fileName;
                }
                // write JSON directly to a file
                using (StreamWriter file = System.IO.File.CreateText(@path))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    o1.WriteTo(writer);
                }
                return RedirectToAction("index", "home");
            }
            
            return View(request);
        }

        [HttpPost]
        public IActionResult ChangeFeatureCategory(ModifyModel request)
        {
            if(ModelState.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin/featureCategories.json");
                var o1 = JArray.Parse(System.IO.File.ReadAllText(@path));
                int index = request.Category.CateIndex;
                o1[index]["maLoai"] = request.Category.MaLoai;
                // write JSON directly to a file
                using (StreamWriter file = System.IO.File.CreateText(@path))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    o1.WriteTo(writer);
                }
                return RedirectToAction("index", "home");
            }
            return View();
        }
        [Route("/admin/cartdetail/{id}")]
        public async Task<IActionResult> CartDetail(string id)
        {
            if (String.IsNullOrEmpty(id)) return NotFound();
            await _service.WatchedGioHang(id);
            return View(await _service.GetGioHangItem(id));
        }
    }
}
