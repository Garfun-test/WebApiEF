using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Interface
{
    public interface IClientsService
    {
        Task AddClients(Clients clients);

        void UpdateClients(int id, Clients clients);

        void DeleteClients(int IdClients);

        Task<Clients> GetClientsById(int IdClients);

        Task<IEnumerable<Clients>> GetAllClients();
                
    }
}