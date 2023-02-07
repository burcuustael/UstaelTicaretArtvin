using UstaelTicaretArtvin.Data;
using UstaelTicaretArtvin.Data.Concrete;
using UstaelTicaretArtvin.Service.Abstract;

namespace UstaelTicaretArtvin.Service.Concrete
{
    public class ProductService : ProductRepository, IProductService
    {
        public ProductService(DatabaseContext _context) : base(_context)
        {
        }
    }
}
