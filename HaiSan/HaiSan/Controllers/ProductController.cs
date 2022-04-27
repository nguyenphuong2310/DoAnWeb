using HaiSan.DI;
using HaiSan.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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


    }
}
