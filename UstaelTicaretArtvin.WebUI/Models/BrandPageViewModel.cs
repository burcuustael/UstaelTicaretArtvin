using UstaelTicaretArtvin.Entities;

namespace UstaelTicaretArtvin.WebUI.Models
{
    public class BrandPageViewModel
    {
        public Brand Brand { get; set; }

        public List<Product>? Products { get; set; }
    }
}
