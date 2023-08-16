using FluentValidation;
using Lorem.Core.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorem.Service.Validations
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
                RuleFor(x=>x.Name).NotNull().WithMessage("{PropertyName} alanı zorunludur").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} alanı 0'dan büyük bir değer almalıdır");
            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} alanı 0'dan büyük bir değer almalıdır");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} alanı 0'dan büyük bir değer almalıdır");
        }
    }
}
