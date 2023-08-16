using Lorem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorem.Core.Repository
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category> CategoryByIdWitProductsAsync(int categoryId);
    }
}
