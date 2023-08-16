using AutoMapper;
using Lorem.Core.Dtos.ProductDtos;
using Lorem.Core.Dtos.ResponseDtos;
using Lorem.Core.Entities;
using Lorem.Core.Repository;
using Lorem.Core.Service;
using Lorem.Core.UnitOfWork;
using Lorem.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lorem.Caching.CachingProducts
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "productcahe";
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IMemoryCache memoryCache, IProductRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _memoryCache = memoryCache;
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _repository.GetAll().ToList());
            }
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CallCacheAllProductsAsync();
            return entity;

        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CallCacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(CacheProductKey));
        }

        public Task<Product> GetByIdAsync(int Id)
        {
            var product = _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == Id);

            if (product == null)
            {
                throw new NotFoundException($"{typeof(Product).Name}({Id}) bulunamadı.");
            }
            return Task.FromResult(product);
        }

        public async Task<CustomResponseDto<List<ProductWithCategory>>> GetProductWithCategory()
        {
            var products = await _repository.GetProductWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategory>>(products);
            return CustomResponseDto<List<ProductWithCategory>>.Success(200, productsDto);
        }

        public async Task RemoveAsync(Product entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CallCacheAllProductsAsync();

        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CallCacheAllProductsAsync();
        }

        public async Task UpdateAsync(Product entity)
        {

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CallCacheAllProductsAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CallCacheAllProductsAsync()
        {
            _memoryCache.Set(CacheProductKey, await _repository.GetAll().ToListAsync());
        }
    }
}
