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

namespace HaiSan.DI
{
    public class ProductService : IProductService
    {
        private readonly HaiSanContext _context;
        public ProductService(HaiSanContext context)
        {
            _context = context;
        }
        public async Task<List<Loaisp>> AllCategory()
        {
            var cates = await _context.Loaisps.ToListAsync();
            return cates;
        }

        public async Task<int> Create(SanPhamCreateRequest request)
        {
            const int WIDTH = 600;
            const int HEIGHT = 800;
            // Tạo unique name cho file
            var fileName = Guid.NewGuid() + Path.GetExtension(request.Img.FileName).ToLower();
            // Resize hình về tỉ lệ chuẩn
            var image = Image.FromStream(request.Img.OpenReadStream());
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

        public async Task<List<Sanpham>> Search(string key)
        {
            var query = _context.Sanphams.Where(e => e.Ten.Contains(key));
            return await PaginatedList<Sanpham>.CreateAsync(query.AsNoTracking(), 1, 15);
        }

        public async Task<int> Update(Sanpham product)
        {
            var prod = _context.Sanphams.Where(e => e.MaSp == product.MaSp).FirstOrDefault();
            if (prod == null) return -1;
            prod = product;
            return await _context.SaveChangesAsync();
        }
    }
}
