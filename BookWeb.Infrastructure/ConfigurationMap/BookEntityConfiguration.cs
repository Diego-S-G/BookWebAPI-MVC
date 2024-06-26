using BookWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWeb.Infrastructure.ConfigurationMap
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));

            builder.HasKey(x => x.Id);

            builder.Property((x) => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(70)
                .IsRequired();

            builder.Property((x) => x.Author)
                .HasColumnName("Author")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property((x) => x.Publisher)
                .HasColumnName("Publisher")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

        }
    }
}