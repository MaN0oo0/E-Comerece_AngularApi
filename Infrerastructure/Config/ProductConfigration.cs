using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrerastructure.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Price).IsRequired();
            builder.Property(a => a.Description).IsRequired();


            //Relations One To Many
            builder.HasOne(a => a.productBrand).WithMany().HasForeignKey(a => a.ProductBrandId);
            builder.HasOne(a => a.productType).WithMany().HasForeignKey(a => a.ProductTypeId);
        }
    }
}
