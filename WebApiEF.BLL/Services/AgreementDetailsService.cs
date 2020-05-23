using WebApiEF.DAL.Interface;
using WebApiEF.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Services
{
    public class AgreementDetailsService : IAgreementDetailsService
    {
        private IUnitOfWork _UnitOfWork;

        public AgreementDetailsService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task AddAgreementDetails(AgreementDetails agreementDetails)
        {
            await _UnitOfWork.AgreementDetailsRepository.Insert(agreementDetails);
        }

        public void DeleteAgreementDetails(int IdAgreement)
        {
            _UnitOfWork.AgreementDetailsRepository.Delete(IdAgreement);
        }

        public async Task<IEnumerable<AgreementDetails>> GetAllAgreementDetails()
        {
            var agreementDetails = await _UnitOfWork.AgreementDetailsRepository.GetAll();
            return agreementDetails;
        }

        public async Task<AgreementDetails> GetAgreementDetailsByIdd(int IdAgreement, int IdProduct)
        {
            var agreementDetails = await _UnitOfWork.AgreementDetailsRepository.GetById2(IdAgreement, IdProduct);
            return agreementDetails;
        }

        public void UpdateAgreementDetails(int id, AgreementDetails agreementDetails)
        {
            _UnitOfWork.AgreementDetailsRepository.Update(id, agreementDetails);
        }

    }
}