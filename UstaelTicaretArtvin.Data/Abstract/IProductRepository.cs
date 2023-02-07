using UstaelTicaretArtvin.Entities;

namespace UstaelTicaretArtvin.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsByCategoriesBrandsAsync();
        Task<Product> GetProductByCategoriesBrandsAsync(int id);
    }
}
