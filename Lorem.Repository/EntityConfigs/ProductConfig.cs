using Lorem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorem.Repository.EntityConfigs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> p)
        {
            p.HasKey(x => x.Id);
            p.Property(x => x.Id).UseIdentityColumn();
            p.Property(x => x.Price).HasColumnType("decimal(18,2)");
            p.ToTable("Products");
            p.HasData(new Product
            {
                Id = 1,
                Name = "Test 1",
                Stock = 120,
                Price = 34,
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            },
            new Product
            {
                Id = 2,
                Name = "Test 2",
                Stock = 420,
                Price = 74,
                CategoryId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
        }
    }
}
