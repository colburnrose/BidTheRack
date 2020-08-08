using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _productType;
        public ProductsController(IMapper mapper, IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrand, IGenericRepository<ProductType> productType)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _productBrand = productBrand;
            _productType = productType;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts([FromQuery]ProductSpecParams specParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(specParams); ;
            var products = await _productRepo.ListAllAsync(spec);
            //return products.Select(product => new ProductDTO
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    ImageUrl = product.ImageUrl,
            //    ProductType = product.ProductType.Name,
            //    ProductBrand = product.ProductBrand.Name
            //}).ToList();
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var brands = await _productBrand.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProducTypes()
        {
            var types = await _productType.GetAllAsync(); 
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(400));

            return _mapper.Map<Product, ProductDTO>(product);
        }
    }
}
