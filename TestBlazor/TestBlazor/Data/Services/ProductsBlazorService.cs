using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace TestBlazor.Data
{
    public class ProductsBlazorService
    {
        string baseUrl = "https://localhost:44393/";

        public async Task<Products[]> GetProductsAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Products/GetProducts");
            return JsonConvert.DeserializeObject<Products[]>(json);
        }

        public async Task<Products> GetProductsByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Products/GetProduct/{id}");
            return JsonConvert.DeserializeObject<Products>(json);
        }

        public async Task<HttpResponseMessage> InsertProductsAsync(Products products)
        {
            var load = new HttpClient();
            return await load.PostAsync($"{baseUrl}api/Products/AddProducts", getStringContentFromObject(products));
        }

        public async Task<HttpResponseMessage> UpdateProductsAsync(string id, Products products)
        {
            var load = new HttpClient();
            return await load.PutAsync($"{baseUrl}api/Products/UpdateProducts/{id}", getStringContentFromObject(products));
        }

        public async Task<HttpResponseMessage> DeleteProductsAsync(string id)
        {
            var products = new HttpClient();
            return await products.DeleteAsync($"{baseUrl}api/Products/RemoveProducts/{id}");
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
