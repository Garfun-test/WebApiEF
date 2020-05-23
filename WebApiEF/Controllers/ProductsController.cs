using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiEF.BLL.DTO;
using WebApiEF.BLL.Interface;
using WebApiEF.DAL.Models;

namespace WebApiEF.Controllers
{
    [Route("/api/Products")]
    public class ProductsController : ControllerBase
    {
        private IProductsService _ProductsService;
        private IMapper _mapper;

        #region Constructors
        public ProductsController(IProductsService service, IMapper mapper)
        {
            _ProductsService = service;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IEnumerable<ProductsDTO>> GetAllProducts()
        {
            var product = await _ProductsService.GetAllProducts();
            var resource = _mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(product);
            return resource;
        }

        [HttpGet]
        [Route("GetProduct/{IdProduct}")]
        public async Task<ProductsDTO> GetProductsById(int IdProduct)
        {
            var product = await _ProductsService.GetProductsById(IdProduct);
            var resource = _mapper.Map<Products, ProductsDTO>(product);
            return resource;
        }

        [HttpPost]
        [Route("AddProducts")]
        public async Task AddProducts([FromBody] ProductsDTO Products)
        {
            var product = _mapper.Map<ProductsDTO, Products>(Products);
            await _ProductsService.AddProducts(product);
        }

        [HttpDelete]
        [Route("RemoveProducts/{IdProduct}")]
        public void DeleteProducts(int IdProduct)
        {
            _ProductsService.DeleteProducts(IdProduct);
        }

        [Route("UpdateProducts")]
        [HttpPut]
        public void UpdateProducts([FromBody]int id, Products products)
        {
            _ProductsService.UpdateProducts(id, products);
        }

    }
}
