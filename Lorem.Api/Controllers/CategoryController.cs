using Lorem.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lorem.Api.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> CategoryByIdWitProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.CategoryByIdWitProductsAsync(categoryId));
        }
    }
}
