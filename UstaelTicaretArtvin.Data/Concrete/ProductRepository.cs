using Microsoft.EntityFrameworkCore;
using UstaelTicaretArtvin.Data.Abstract;
using UstaelTicaretArtvin.Entities;

namespace UstaelTicaretArtvin.Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoriesBrandsAsync()
        {
            return await context.Products.Include(c => c.Category).Include(c => c.Brand).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductByCategoriesBrandsAsync(int id)
        {
            return await context.Products.Include(c => c.Category).Include(b => b.Brand).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
