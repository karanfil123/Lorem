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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> c)
        {
            c.HasKey(x => x.Id);
            c.Property(x => x.Id).UseIdentityColumn();
            c.ToTable("Categories");
            c.HasData(new Category
            {
                Id = 1,
                Name = "Name Category 1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            },
            new Category
            {
                Id = 2,
                Name = "Name Category 2",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
        }
    }
}
