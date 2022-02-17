using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using AutoMapper;
using ECommerceApp.API.Data;
using ECommerceApp.API.Dtos;
using ECommerceApp.API.Models;
using ECommerceApp.API.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;

        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductForCreationDto productForCreationDto)
        {
            var productToCreated = mapper.Map<Product>(productForCreationDto);

            productRepository.Add(productToCreated);

            if (await productRepository.SaveAll())
                return Ok();

            return BadRequest("Failed to add the product.");
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CategoryForCreationDto categoryForCreationDto)
        {
            var categoryToCreated = mapper.Map<Category>(categoryForCreationDto);

            productRepository.Add(categoryToCreated);

            if (await productRepository.SaveAll())
                return Ok();

            return BadRequest("Failed to add the category.");
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams productParams)
        {
            var items = await productRepository.GetAllProducts(productParams);

            var itemsToReturn = mapper.Map<IEnumerable<ProductForListDto>>(items);

            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(itemsToReturn);
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery] ProductParams productParams)
        {
            var items = await productRepository.GetAllCategories(productParams);

            var itemsToReturn = mapper.Map<IEnumerable<CategoryForListDto>>(items);

            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(itemsToReturn);
        }

    }
}