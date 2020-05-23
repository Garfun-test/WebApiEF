using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Interface
{
    public interface IProductsService
    {
        Task AddProducts(Products products);

        void UpdateProducts(int id, Products products);

        void DeleteProducts(int IdProduct);

        Task<Products> GetProductsById(int IdProduct);

        Task<IEnumerable<Products>> GetAllProducts();

    }
}