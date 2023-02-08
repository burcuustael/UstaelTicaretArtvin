using UstaelTicaretArtvin.Data;
using UstaelTicaretArtvin.Data.Concrete;
using UstaelTicaretArtvin.Service.Abstract;

namespace UstaelTicaretArtvin.Service.Concrete
{
    public class CategoryService : CategoryRepository, ICategoryService
    {
        public CategoryService(DatabaseContext _context) : base(_context)
        {
        }
    }
}
