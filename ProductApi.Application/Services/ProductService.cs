using ProductApi.Application.Dtos;
using ProductApi.Application.Interfaces;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock
            };
            await _productRepository.CreateAsync(values);

        }

        public async Task DeleteProductAsync(int id)
        {
             await _productRepository.DeleteAsync(id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
           var values = await _productRepository.GetAllAsync();

            return values.Select(p => new ResultProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
            }).ToList();


        }

        public async Task<GetProductDetailByIdDto> GetProductByIdAsync(int id)
        {
            var values = await _productRepository.GetByIdAsync(id)
                   ?? throw new Exception("Product not found");

            return new GetProductDetailByIdDto
            {
                ProductId = values.ProductId,
                Name = values.Name,
                Description = values.Description,
                Price = values.Price,
                Stock = values.Stock
            };
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = await _productRepository.GetByIdAsync(updateProductDto.ProductId);

            values.Name = updateProductDto.Name;
            values.Description = updateProductDto.Description;
            values.Price = updateProductDto.Price;
            values.Stock = updateProductDto.Stock;

            await _productRepository.UpdateAsync(values);
        }
    }
}
