using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DevInSales.Core.Entities;
namespace DevInSales.Core.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            // Opcional, pois por convenção nossa propriedade já seria a chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.SuggestedPrice)
                .HasColumnType("decimal(18,2)")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();
        }
    }

}
