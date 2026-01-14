using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace BookManageSystem
{
    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks {  get; set; }
        public DbSet<BookItem> BookItems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<RentalHistory> RentalHistories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MariaDBConnection"].ConnectionString;

            // MySQL, MariaDB用のプロバイダーを使用
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AuthorBookエンティティに複合キー（IsbnとAuthorId）を設定
            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.Isbn, ab.AuthorId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
