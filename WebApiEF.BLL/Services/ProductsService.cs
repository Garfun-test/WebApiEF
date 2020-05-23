using WebApiEF.DAL.Interface;
using WebApiEF.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Services
{
    public class ProductsService : IProductsService
    {
        private IUnitOfWork _UnitOfWork;

        public ProductsService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task AddProducts(Products products)
        {
            await _UnitOfWork.ProductsRepository.Insert(products);
        }

        public void DeleteProducts(int IdProduct)
        {
            _UnitOfWork.ProductsRepository.Delete(IdProduct);
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var products = await _UnitOfWork.ProductsRepository.GetAll();
            return products;
        }

        public async Task<Products> GetProductsById(int IdProduct)
        {
            var products = await _UnitOfWork.ProductsRepository.GetById(IdProduct);
            return products;
        }

        public void UpdateProducts(int id,Products products)
        {
            _UnitOfWork.ProductsRepository.Update(id, products);
        }

    }
}