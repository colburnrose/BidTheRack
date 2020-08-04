using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _ctx;
        public ProductRepository(StoreContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _ctx.Products.Include(o => o.ProductBrand).Include(o => o.ProductType).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync() => await _ctx.ProductBrands.ToListAsync();
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _ctx.Products.Include(o => o.ProductBrand).Include(o => o.ProductType).ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync() => await _ctx.ProductTypes.ToListAsync();
    }
}
