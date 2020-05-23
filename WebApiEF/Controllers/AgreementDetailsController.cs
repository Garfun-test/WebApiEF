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
    [Route("/api/AgreementDetails")]
    public class AgreementDetailsController : ControllerBase
    {
        private IAgreementDetailsService _AgreementDetailsService;
        private IMapper _mapper;

        #region Constructors
        public AgreementDetailsController(IAgreementDetailsService service, IMapper mapper)
        {
            _AgreementDetailsService = service;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        [Route("GetAgreementDetails")]
        public async Task<IEnumerable<AgreementDetailsDTO>> GetAllAgreementDetails()
        {
            var agreementDetails = await _AgreementDetailsService.GetAllAgreementDetails();
            var resource = _mapper.Map<IEnumerable<AgreementDetails>, IEnumerable<AgreementDetailsDTO>>(agreementDetails);
            return resource;
        }

        [HttpGet]
        [Route("GetAgreementDetails/{IdAgreement}/{idProduct}")]
        public async Task<AgreementDetailsDTO> GetAgreementDetailsById(int IdAgreement, int IdProduct)
        {
            var agreementDetails = await _AgreementDetailsService.GetAgreementDetailsByIdd(IdAgreement, IdProduct);
            var resource = _mapper.Map<AgreementDetails, AgreementDetailsDTO>(agreementDetails);
            return resource;
        }

        [HttpPost]
        [Route("AddAgreementDetails")]
        public async Task AddAgreementDetails([FromBody] AgreementDetailsDTO AgreementDetails)
        {
            var agreementDetails = _mapper.Map<AgreementDetailsDTO, AgreementDetails>(AgreementDetails);
            await _AgreementDetailsService.AddAgreementDetails(agreementDetails);
        }

        [HttpDelete]
        [Route("RemoveAgreementDetails/{IdAgreement}")]
        public void DeleteAgreementDetails(int IdAgreement)
        {
            _AgreementDetailsService.DeleteAgreementDetails(IdAgreement);
        }

        [Route("UpdateAgreementDetails")]
        [HttpPut]
        public void UpdateAgreementDetails([FromBody]int id, AgreementDetails agreementDetails)
        {
            _AgreementDetailsService.UpdateAgreementDetails(id, agreementDetails);
        }

    }
}
