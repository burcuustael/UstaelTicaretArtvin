using System.ComponentModel.DataAnnotations;

namespace UstaelTicaretArtvin.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " {0} alanı boş geçilemez!"), StringLength(50), Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }

        [StringLength(150), Display(Name = "Kategori Resmi")]
        public string? Image { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }

        [Display(Name = "Üst Menüde Göster")]
        public bool IsTopMenu { get; set; }

        [Display(Name = "Üst Kategori")]

        public int ParentId { get; set; }

        [Display(Name ="Kategori Sıra No")]
        public int OrderNo { get; set; }

        public virtual ICollection<Product>? Products { get; set; }

    }
}
