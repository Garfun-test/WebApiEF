using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Interface
{ 
    public interface IAgreementService
    {
        Task AddAgreement(Agreement agreement);

        void UpdateAgreement(int id, Agreement agreement);

        void DeleteAgreement(int IdAgreement);

        Task<Agreement> GetAgreementById(int IdAgreement);

        Task<IEnumerable<Agreement>> GetAgreementList();

        IQueryable<Object> GetDogovor();

    }
}