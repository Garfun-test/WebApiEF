using WebApiEF.DAL.Interface;
using WebApiEF.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Services
{
    public class AgreementService : IAgreementService
    {
        private IUnitOfWork _UnitOfWork;

        public AgreementService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task AddAgreement(Agreement agreement)
        {
            await _UnitOfWork.AgreementRepository.Insert(agreement);
        }

        public void DeleteAgreement(int IdAgreement)
        {
            _UnitOfWork.AgreementRepository.Delete(IdAgreement);
        }

        public async Task<IEnumerable<Agreement>> GetAgreementList()
        {
            var agreement = await _UnitOfWork.AgreementRepository.GetAgreementList();
            return agreement;
        }

        public async Task<Agreement> GetAgreementById(int IdAgreement)
        {
            var agreement = await _UnitOfWork.AgreementRepository.GetById(IdAgreement);
            return agreement;
        }

        public void UpdateAgreement(int id, Agreement agreement)
        {
            _UnitOfWork.AgreementRepository.Update(id, agreement);
        }


        public IQueryable<Object> GetDogovor()
        {
            return _UnitOfWork.AgreementRepository.GetDogovor();
        }

    }
}