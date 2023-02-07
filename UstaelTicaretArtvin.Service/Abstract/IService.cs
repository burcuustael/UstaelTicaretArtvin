using UstaelTicaretArtvin.Data.Abstract;
using UstaelTicaretArtvin.Entities;

namespace UstaelTicaretArtvin.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {

    }
}
