using Lorem.Core.Entities;
using Lorem.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lorem.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public Task<List<Product>> GetProductWithCategory()
        {
            return _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}