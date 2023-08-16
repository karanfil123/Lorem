using AutoMapper;
using Lorem.Core.Dtos.ProductDtos;
using Lorem.Core.Dtos.ResponseDtos;
using Lorem.Core.Entities;
using Lorem.Core.Repository;
using Lorem.Core.Service;
using Lorem.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorem.Service.Services
{
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductServiceWithNoCaching(IUnitOfWork unitOfWork,IGenericRepository<Product> genericRepository, IProductRepository productRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategory>>> GetProductWithCategory()
        {
            var products = await _productRepository.GetProductWithCategory();
            var productDto = _mapper.Map<List<ProductWithCategory>>(products);
            return CustomResponseDto<List<ProductWithCategory>>.Success(200, productDto);
        }
       
    }
}
