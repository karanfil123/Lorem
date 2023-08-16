using Lorem.Core.Dtos.ProductDtos;
using Lorem.Core.Dtos.ResponseDtos;
using Lorem.Core.Entities;
using Lorem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorem.Core.Service
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategory>>> GetProductWithCategory();
    }
}
