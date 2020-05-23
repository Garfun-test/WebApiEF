using WebApiEF.DAL.Interface;
using WebApiEF.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Services
{
    public class ClientsService : IClientsService
    {
        private IUnitOfWork _UnitOfWork;

        public ClientsService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task AddClients(Clients clients)
        {
            await _UnitOfWork.ClientsRepository.Insert(clients);
        }

        public void DeleteClients(int IdClient)
        {
            _UnitOfWork.ClientsRepository.Delete(IdClient);
        }

        public async Task<IEnumerable<Clients>> GetAllClients()
        {
            var clients = await _UnitOfWork.ClientsRepository.GetAll();
            return clients;
        }

        public async Task<Clients> GetClientsById(int IdClient)
        {
            var clients = await _UnitOfWork.ClientsRepository.GetById(IdClient);
            return clients;
        }

        public void UpdateClients(int id, Clients clients)
        {
            _UnitOfWork.ClientsRepository.Update(id, clients);
        }
                
    }
}