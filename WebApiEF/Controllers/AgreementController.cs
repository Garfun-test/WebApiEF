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
    [Route("/api/Agreement")]
    public class AgreementController : ControllerBase
    {
        private IAgreementService _AgreementService;
        private IMapper _mapper;

        #region Constructors
        public AgreementController(IAgreementService service, IMapper mapper)
        {
            _AgreementService = service;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        [Route("GetAgreement")]
        public async Task<IEnumerable<AgreementDTO>> GetAgreementList()
        {
            var agreement = await _AgreementService.GetAgreementList();
            var resource = _mapper.Map<IEnumerable<Agreement>, IEnumerable<AgreementDTO>>(agreement);
            return resource;
        }

        [HttpGet]
        [Route("GetAgreement/{IdAgreement}")]
        public async Task<AgreementDTO> GetAgreementById(int IdAgreement)
        {
            var agreement = await _AgreementService.GetAgreementById(IdAgreement);
            var resource = _mapper.Map<Agreement, AgreementDTO>(agreement);
            return resource;
        }

        [HttpPost]
        [Route("AddAgreement")]
        public async Task AddAgreement([FromBody] SaveAgreementDTO Agreement)
        {
            var agreement = _mapper.Map<SaveAgreementDTO, Agreement>(Agreement);
            await _AgreementService.AddAgreement(agreement);
        }

        [HttpDelete]
        [Route("RemoveAgreement/{IdAgreement}")]
        public void DeleteAgreement(int IdAgreement)
        {
            _AgreementService.DeleteAgreement(IdAgreement);
        }

        [Route("UpdateAgreement")]
        [HttpPut]
        public void UpdateAgreement([FromBody]int id, Agreement agreement)
        {
            _AgreementService.UpdateAgreement(id, agreement);
        }


        [Route("GetDogovor")]
        [HttpGet]
        public IQueryable<Object> GetDovogor()
        {
            return _AgreementService.GetDogovor();
        }
        
    }
}
