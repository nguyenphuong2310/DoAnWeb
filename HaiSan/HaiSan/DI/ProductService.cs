using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Authorization;
using HaiSan.Models.Pure;
using HaiSan.Models.View;
using HaiSan.Ulti;
using Microsoft.AspNetCore.Http;

namespace HaiSan.DI
{
    public class ProductService : IProductService
    {
        private readonly HaiSanContext _context;
        public ProductService(HaiSanContext context)
        {
            _context = context;
        }
        public async Task<int> ChangeStatus(string id, short status)
        {
            var gh = await _context.Giohangs.FindAsync(id);
            if (gh == null) return 0;
            if (status < 0 || status > 4) return 0;
            gh.Status = status;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> WatchedGioHang(string id)
        {
            var gh = await _context.Giohangs.FindAsync(id);
            if (gh == null) return 0;
            gh.Watched = true;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Loaisp>> AllCategory()
        {
            var cates = await _context.Loaisps.ToListAsync();
            return cates;
        }
        public List<Sanpham> GetAllProductByUsername(string id)
        {
            var prods = _context.Sanphams.Where(e => e.Username == id).ToList();
            return prods;
        }
        private async Task<string> SaveProductImageAsync(IFormFile Img)
        {
            const int WIDTH = 600;
            const int HEIGHT = 800;
            // Tạo unique name cho file
            var fileName = Guid.NewGuid() + Path.GetExtension(Img.FileName).ToLower();
            // Resize hình về tỉ lệ chuẩn
            var image = Image.FromStream(Img.OpenReadStream());
            var resized = new Bitmap(image, new System.Drawing.Size(WIDTH, HEIGHT));
            using var imageStream = new MemoryStream();
            resized.Save(imageStream, ImageFormat.Png);
            var imageBytes = imageStream.ToArray();
            // Lưu file vào wwwroot/assets/img folder

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", fileName);

            await File.WriteAllBytesAsync(filePath, imageBytes);

            // cái này để lưu thẳng từ IFormFile
            /*using (var stream = File.Create(filePath))
            {
                await request.Img.CopyToAsync(stream);
            }*/
            return fileName;
        }

        public async Task<int> Create(SanPhamCreateRequest request)
        {
            var fileName = await SaveProductImageAsync(request.Img);
            // create new product
            var prod = new Sanpham()
            {
                MaSp = Guid.NewGuid().ToString(),
                DateCreated = DateTime.Now,
                Ten = request.Ten,
                Gia = request.Gia,
                MoTa = request.MoTa,
                Title = request.Title,
                Img = fileName,
                Soluong = request.Soluong,
                Username = request.Username,
                IdSize = request.IdSize,
                MaLoai = request.MaLoai
            };
            await _context.Sanphams.AddAsync(prod);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string productId)
        {
            var prod = (from e in _context.Sanphams
                        where e.MaSp == productId
                        select e).FirstOrDefault();
            _context.Sanphams.Remove(prod);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Sanpham>> GetAllByCategoryIdPaging(string categoryId, int pageIndex, int limit)
        {
            IQueryable<Sanpham> query;
            if (categoryId == "all")
            {
                query = _context.Sanphams;
            }
            else
            {
                query = _context.Sanphams.Where(e => e.MaLoai == categoryId);
            }

            return await PaginatedList<Sanpham>.CreateAsync(query.AsNoTracking(), pageIndex, limit);
        }

        public async Task<List<Sanpham>> GetAllPaging(int pageIndex, int limit)
        {
            IQueryable<Sanpham> query = _context.Sanphams;
            return await PaginatedList<Sanpham>.CreateAsync(query.AsNoTracking(), pageIndex, limit);
        }

        public async Task<Sanpham> GetById(string productId)
        {
            return await _context.Sanphams.FindAsync(productId);
        }
        public async Task<List<Sanpham>> Search(string key, int page)
        {
            var query = _context.Sanphams.Where(e => e.Ten.Contains(key));
            return await PaginatedList<Sanpham>.CreateAsync(query.AsNoTracking(), page, 15);
        }

        public async Task<int> Update(SanPhamUpdateRequest request)
        {
            string fileName = null;
            if (request.Img != null)
            {
                fileName = await SaveProductImageAsync(request.Img);
            }
            var prod = _context.Sanphams.Where(e => e.MaSp == request.MaSp).FirstOrDefault();
            prod.DateCreated = DateTime.Now;
            prod.Ten = request.Ten;
            prod.Gia = request.Gia;
            prod.MoTa = request.MoTa;
            prod.Title = request.Title;
            prod.Img = fileName ?? prod.Img;
            prod.Username = request.Username;
            prod.Soluong = request.Soluong;
            prod.IdSize = request.IdSize;
            prod.MaLoai = request.MaLoai;
            return await _context.SaveChangesAsync();
        }

        public async Task<Loaisp> GetCategoryById(string id)
        {
            return await _context.Loaisps.FindAsync(id);
        }

        public async Task<int> Buy(Giohang giohang, List<Item> items)
        {
            await _context.AddAsync(giohang);
            var res = await _context.SaveChangesAsync();
            if (res == 0) return 0;
            foreach(var e in items)
            {
                await _context.AddAsync(e);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveItem(ItemGioHang item)
        {
            var i = _context.Items.Where(e => e.IdGioHang == item.Id && e.MaSp == item.MaSp).FirstOrDefault();
            if(i != null)
            {
                _context.Remove(i);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> RemoveGioHang(string id)
        {
            var i = _context.Items.Where(e => e.IdGioHang == id).ToList();
            _context.RemoveRange(i);
            await _context.SaveChangesAsync();
            var e = await _context.Giohangs.FindAsync(id);
            _context.Giohangs.Remove(e);
            return await _context.SaveChangesAsync();
        }

        public async Task<Giohang> GetGioHang(string id)
        {
            return await _context.Giohangs.FindAsync(id);
        }

        public List<Giohang> GetGioHangWatched()
        {
           return _context.Giohangs.Where(e => e.Watched == false).ToList();
        }
        async Task<List<CartItem>> GetGioHangItemAsync(string idGioHang)
        {
            var items = _context.Items.Where(e => e.IdGioHang == idGioHang).ToList();
            List<CartItem> listItems = new List<CartItem>();
            foreach (var e in items)
            {
                var prod = await _context.Sanphams.FindAsync(e.MaSp);
                CartItem item = new CartItem()
                {
                    MaSP = prod,
                    Sl = e.SoluongMua
                };
                listItems.Add(item);
            }
            return listItems;
        }
        public async Task<GioHangModel> GetGioHangItem(string idGioHang)
        {
            var gh = await GetGioHang(idGioHang);
            
            GioHangModel res = new GioHangModel();
            res.toGioHangModel(gh);
            res.Products = await GetGioHangItemAsync(idGioHang);
            return res;
        }

        public List<Giohang> GetAllGioHang()
        {
            return _context.Giohangs.OrderBy(e => e.Status).ToList();
        }

        public async Task<List<ThongKe>> GetMonthlyStatistics(int year)
        {
            var ghsQuery = from gh in _context.Giohangs
                            join i in _context.Items on gh.IdGioHang equals i.IdGioHang
                            join sp in _context.Sanphams on i.MaSp equals sp.MaSp
                            where gh.DateCreated.Year == year
                            select new
                            {
                                Id = gh.IdGioHang,
                                Gia = sp.Gia,
                                Thang = gh.DateCreated.Month,
                                Sl = i.SoluongMua
                            };
            var res = from e in ghsQuery
                      group e by new
                      {
                          Month = e.Thang
                      } into q
                      select new ThongKe()
                      {
                          Thang = q.Key.Month,
                          Total = q.Sum(e => e.Sl * e.Gia)
                      };
            var month = await res.ToListAsync();
            
            return month;
        }
    }
}
