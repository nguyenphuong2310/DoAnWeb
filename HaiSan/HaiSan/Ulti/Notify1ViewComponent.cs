using HaiSan.DI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Ulti
{
    [ViewComponent(Name = "Notify1")]
    public class Notify1ViewComponent : ViewComponent
    {
        private readonly IProductService _service;
        public Notify1ViewComponent(IProductService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index", _service.GetGioHangWatched());
        }

    }
}
