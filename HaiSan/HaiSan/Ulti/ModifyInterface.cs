using HaiSan.DI;
using HaiSan.Models.Pure;
using HaiSan.Models.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.Ulti
{
    public class ModifyInterface
    {
        private readonly IProductService _service;
        public ModifyInterface(IProductService service)
        {
            _service = service;
        }
        public async Task<HomeModel> GetHomeModelAsync()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin/banner.json");
            var o1 = JArray.Parse(File.ReadAllText(@path));
            List<Banner> list = new List<Banner>();
            for (int i = 0; i < o1.Count(); i++)
            {
                Banner b = new()
                {
                    Id = i,
                    Title = o1[i]["title"].ToString(),
                    Content = o1[i]["content"].ToString(),
                    Path = o1[i]["path"].ToString(),
                };
                list.Add(b);
            }
            path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin/featureProducts.json");
            o1 = JArray.Parse(File.ReadAllText(@path));
            List<Sanpham> list2 = new List<Sanpham>();
            for (int i = 0; i < o1.Count(); i++)
            {
                Sanpham sp = await _service.GetById(o1[i]["MaSp"].ToString());
                list2.Add(sp);
            };
            path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin/featureCategories.json");
            o1 = JArray.Parse(File.ReadAllText(@path));
            List<Loaisp> list3 = new List<Loaisp>();
            for (int i = 0; i < o1.Count(); i++)
            {
                Loaisp sp = await _service.GetCategoryById(o1[i]["maLoai"].ToString());
                list3.Add(sp);
            };
            HomeModel model = new()
            {
                Banner = list,
                FeatureProducts = list2,
                FeatuteCategories = list3
            };
            return model;
        }
    }
}
