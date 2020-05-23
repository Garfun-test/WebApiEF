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
    [Route("/api/Clients")]
    public class ClientsController : ControllerBase
    {
        private IClientsService _ClientsService;
        private IMapper _mapper;

        #region Constructors
        public ClientsController(IClientsService service, IMapper mapper)
        {
            _ClientsService = service;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        [Route("GetClients")]
        public async Task<IEnumerable<ClientsDTO>> GetAllClients()
        {
            var clients = await _ClientsService.GetAllClients();
            var resource = _mapper.Map<IEnumerable<Clients>, IEnumerable<ClientsDTO>>(clients);
            return resource;
        }

        [HttpGet]
        [Route("GetClient/{IdClients}")] 
        public async Task<ClientsDTO> GetClientsById(int IdClients)
        {
            var clients = await _ClientsService.GetClientsById(IdClients);
            var resource = _mapper.Map<Clients, ClientsDTO>(clients);
            return resource;
        }

        [HttpPost]
        [Route("AddClients")]
        public async Task AddClients([FromBody] ClientsDTO Client)
        {
            var client = _mapper.Map <ClientsDTO, Clients>(Client);
            await _ClientsService.AddClients(client);
        }

        [HttpDelete]
        [Route("RemoveClients/{IdClients}")]
        public void DeleteClients(int IdClients)
        {
            _ClientsService.DeleteClients(IdClients);
        }

        [Route("UpdateClients/{id}")]
        [HttpPut]
        public void UpdateClients(int id, [FromBody] Clients clients)
        {
            _ClientsService.UpdateClients(id, clients);
        }
                
    }
}
