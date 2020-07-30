using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
            return await _ctx.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync() => await _ctx.Products.ToListAsync();
    }
}
