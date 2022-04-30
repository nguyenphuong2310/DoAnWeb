using HaiSan.DI;
using HaiSan.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaiSan.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _service;
        public ProductController(ILogger<ProductController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [Route("/products/{category}")]
        public async Task<IActionResult> Index(string category, int page = 1, int limit = 15)
        {
            ViewData["Categories"] = await _service.AllCategory();
            ViewData["Category"] = category;
            var res = await _service.GetAllByCategoryIdPaging(category, page, limit);
            return View(res);
        }
        [Route("/products/detail")]
        public async Task<IActionResult> Detail(string id)
        {
            var prod = await _service.GetById(id);
            if(prod == null)
            {
                return NotFound();
            }
            var relateProd = await _service.GetAllByCategoryIdPaging(prod.MaLoai, 1, 20);
            DetailModel model = new DetailModel()
            {
                SanPham = prod,
                RelateProd = relateProd
            };
            return View(model);
        }
        [Route("/products/create")]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await _service.AllCategory();
            return View();
        }
        [Authorize]
        [Route("/products/create")]
        [HttpPost]
        public async Task<IActionResult> Create(SanPhamCreateRequest prod) 
        {
            if(ModelState.IsValid)
            {
                var res = await _service.Create(prod);
                if (res == 0)
                {
                    return NotFound();
                }
                return RedirectToAction("manager", "user");
            }
            return View(prod);
        }
        [Authorize]
        [Route("/products/update")]
        public async Task<IActionResult> Update(string id)
        {
            var prod = await _service.GetById(id);
            var userId = User.Identity.Name;
            if (userId != prod.Username || prod == null)
            {
                return NotFound();
            }
            ViewData["Categories"] = await _service.AllCategory();
            ViewData["Product"] = prod;
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("/products/update")]
        public async Task<IActionResult> Update(SanPhamUpdateRequest prod)
        {
            if(ModelState.IsValid)
            {
                var product = await _service.GetById(prod.MaSp);
                var userId = User.Identity.Name;
                if (product == null || userId != product.Username)
                {
                    return NotFound();
                }
                var res = await _service.Update(prod);
                if (res == 0)
                {
                    return NotFound();
                }
                return RedirectToAction("manager", "user");
            }
            return View(prod);
        }
        [Authorize]
        [HttpPost]
        [Route("/products/delete")]
        public async Task<bool> Delete([FromBody]IdRequest prod)
        {
            var product = await _service.GetById(prod.Id);
            var userId = User.Identity.Name;
            if (product == null || userId != product.Username)
            {
                return false;
            }
            
            var res = await _service.Delete(product.MaSp);
            return res != 0;
        }


    }
}
