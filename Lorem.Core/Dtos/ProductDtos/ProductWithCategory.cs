using Lorem.Core.Dtos.CategoryDtos;
using Lorem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorem.Core.Dtos.ProductDtos
{
    public class ProductWithCategory : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
