using Lorem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lorem.Repository.EntityConfigs
{
    public class ProductFeatureConfig : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> pf)
        {
            pf.HasKey(x => x.Id);
            pf.Property(x => x.Id).UseIdentityColumn();
            pf.ToTable("ProductFeatures");
            pf.HasData(new ProductFeature
            {
                Id = 1,
                Color="Red",
                Height="4 metre",
                Width="2 metre",
                ProductId=1,
            },
            new ProductFeature
            {
                Id = 2,
                Color = "Black",
                Height = "178mm",
                Width = "50mm",
                ProductId = 2,
            });
        }
    }
}
