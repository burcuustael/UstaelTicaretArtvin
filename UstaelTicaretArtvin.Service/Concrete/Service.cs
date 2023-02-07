using UstaelTicaretArtvin.Data.Concrete;
using UstaelTicaretArtvin.Data;
using UstaelTicaretArtvin.Entities;
using UstaelTicaretArtvin.Service.Abstract;

namespace UstaelTicaretArtvin.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext _context) : base(_context)
        {
        }
    }
}
