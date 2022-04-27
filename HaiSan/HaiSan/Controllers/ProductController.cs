using HaiSan.DI;
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


    }
}
