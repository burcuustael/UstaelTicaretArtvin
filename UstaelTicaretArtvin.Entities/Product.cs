using System.ComponentModel.DataAnnotations;

namespace UstaelTicaretArtvin.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50), Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        public string? Description { get; set; }
        [StringLength(150), Display(Name = "Ürün Resmi")]
        public string? Image { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "Güncelleme Tarihi"), ScaffoldColumn(false)]
        public DateTime? UpdateDate { get; set; } = DateTime.Now;

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfa")]
        public bool IsHome { get; set; }

        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Display(Name = "Marka")]
        public int BrandId { get; set; }

        public Brand? Brand { get; set; }
    }
}
