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
        Task<List<ThongKe>> GetMonthlyStatistics(int year);
        Task<int> ChangeStatus(string id, short status);
        List<Giohang> GetAllGioHang();
        Task<int> WatchedGioHang(string id);
        Task<GioHangModel> GetGioHangItem(string idGioHang);
        List<Giohang> GetGioHangWatched();
        Task<Giohang> GetGioHang(string id);
        Task<int> RemoveGioHang(string id);
        Task<int> RemoveItem(ItemGioHang item);
        Task<int> Buy(Giohang giohang, List<Item> items);
        Task<int> Create(SanPhamCreateRequest request);

        Task<int> Update(SanPhamUpdateRequest product);

        Task<int> Delete(string productId);

        Task<List<Sanpham>> Search(string key, int page);

        Task<Sanpham> GetById(string productId);

        Task<List<Loaisp>> AllCategory();

        Task<Loaisp> GetCategoryById(string id);

        Task<List<Sanpham>> GetAllPaging(int pageIndex, int limit);

        Task<List<Sanpham>> GetAllByCategoryIdPaging(string categoryId, int pageIndex, int limit);

        List<Sanpham> GetAllProductByUsername(string id);
    }
}
