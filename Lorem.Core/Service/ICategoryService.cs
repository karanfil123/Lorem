using Lorem.Core.Dtos.CategoryDtos;
using Lorem.Core.Dtos.ResponseDtos;
using Lorem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorem.Core.Service
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithProductsDto>> CategoryByIdWitProductsAsync(int categoryId);
    }
}
