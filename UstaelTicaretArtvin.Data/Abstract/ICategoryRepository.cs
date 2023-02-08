using UstaelTicaretArtvin.Entities;

namespace UstaelTicaretArtvin.Data.Abstract
{
    public interface ICategoryRepository: IRepository<Category>

    {
        Task<Category> GetCategoryByProducts(int id);
    }
}
