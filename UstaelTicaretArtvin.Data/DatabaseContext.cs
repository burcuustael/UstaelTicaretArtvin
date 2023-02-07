using Microsoft.EntityFrameworkCore;
using UstaelTicaretArtvin.Entities;

namespace UstaelTicaretArtvin.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB; database=UstaelTicaretArtvin; integrated security= true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Phone = "",
                    Email = "ustaelticaret@hotmail.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "admin",
                    Surname = "admin",
                    Password = "0808"
                }
                );

            base.OnModelCreating(modelBuilder);
        }


    }
}
