using Microsoft.EntityFrameworkCore;

namespace ProductExplorer.EfModel
{
    public partial class ProductDbContext : DbContext
    {
        public static readonly string NpgsqlDateNowFunction = "(now())";

        public virtual DbSet<Product> Product { get; set; }

        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("User Id=postgres;Host=localhost;Database=postgres;Persist Security Info=True;password=MV5I0W");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.AddedDate)
                    .IsRequired()
                    .HasDefaultValueSql(NpgsqlDateNowFunction);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Name)
                    .IsUnique()
                    .HasName("UQ_Product_Name");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000); 
            });
        }
    }
}
