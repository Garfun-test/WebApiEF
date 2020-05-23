using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.DTO
{
    public class ClientsDTO
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }

    }
}
