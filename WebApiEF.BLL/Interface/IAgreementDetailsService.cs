using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Interface
{
    public interface IAgreementDetailsService
    {
        Task AddAgreementDetails(AgreementDetails agreementDetails);

        void UpdateAgreementDetails(int id, AgreementDetails agreementDetails);

        void DeleteAgreementDetails(int IdAgreement);

        Task<AgreementDetails> GetAgreementDetailsByIdd(int IdAgreement, int IdProduct);

        Task<IEnumerable<AgreementDetails>> GetAllAgreementDetails();

    }
}