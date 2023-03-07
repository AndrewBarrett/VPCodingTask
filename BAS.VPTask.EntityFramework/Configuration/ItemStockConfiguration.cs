using BAS.VPTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAS.VPTask.EntityFramework.Configuration
{
    class ItemStockConfiguration : IEntityTypeConfiguration<ItemStock>
    {
        public void Configure(EntityTypeBuilder<ItemStock> builder)
        {
            builder.ToTable("ItemStocks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Cost)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.CurrentStock)
                .IsRequired();
        }
    }
}