using HaiSan.Models.Pure;
using HaiSan.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiSan.DI
{
    public interface IProductService
    {
        Task<int> Create(SanPhamCreateRequest request);

        Task<int> Update(Sanpham product);

        Task<int> Delete(string productId);

        Task<List<Sanpham>> Search(string key);

        Task<Sanpham> GetById(string productId);

        Task<List<Loaisp>> AllCategory();

        Task<List<Sanpham>> GetAllPaging(int pageIndex, int limit);

        Task<List<Sanpham>> GetAllByCategoryIdPaging(string categoryId, int pageIndex, int limit);
    }
}
