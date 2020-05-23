using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Interface;
using WebApiEF.DAL.Models;

namespace WebApiEF.DAL.Repository.SQL_Repository
{
    public class ClientsRepository : GenericRepository<Clients>, IClientsRepository
    {
        public ClientsRepository(EFTestContext context) : base(context)
        {

        }
    }
}
