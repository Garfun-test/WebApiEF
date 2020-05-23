using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.DTO
{
    public class ProductsDTO
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public double PriceRetail { get; set; }
        public double PriceWholesale { get; set; }
        public string Description { get; set; }

    }
}
