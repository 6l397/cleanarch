using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace reviewservice.Infrastructure.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(e => e.ReviewId).HasName("PRIMARY");

            builder.ToTable("reviews");

            builder.Property(e => e.ReviewId)
                .HasColumnName("review_id");

            builder.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content")
                .IsRequired();

            builder.Property(e => e.Rating)
                .HasColumnName("rating");

            builder.Property(e => e.ReviewDate)
                .HasColumnName("review_date");

            builder.Property(e => e.SellerId)
                .HasColumnName("seller_id");

            builder.Property(e => e.ServiceId)
                .HasColumnName("service_id");
        }
    }
}
