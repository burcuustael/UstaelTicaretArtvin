using System.ComponentModel.DataAnnotations;

namespace UstaelTicaretArtvin.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50), Display(Name = "Marka Adı")]
        public string Name { get; set; }

        [Display(Name = "Marka Açıklaması")]
        public string? Description { get; set; }
        [StringLength(150)]
        public string? Logo { get; set; } = "";
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public virtual ICollection<Product>? Products { get; set; }
    }
}
