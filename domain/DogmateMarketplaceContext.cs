using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using domain.Entities;

namespace domain
{
    public partial class DogmateMarketplaceContext : DbContext
    {
        public DogmateMarketplaceContext()
        {
        }

        public DogmateMarketplaceContext(DbContextOptions<DogmateMarketplaceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=dogmate_marketplace;User Id=root;Password=36Ozazam;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewId).HasName("PRIMARY");

                entity.ToTable("reviews");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");
                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");
                entity.Property(e => e.Rating).HasColumnName("rating");
                entity.Property(e => e.ReviewDate).HasColumnName("review_date");
                entity.Property(e => e.SellerId).HasColumnName("seller_id");
                entity.Property(e => e.ServiceId).HasColumnName("service_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
