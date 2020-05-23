using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.DAL.Interface
{
    public interface IAgreementRepository : IGenericRepository<Agreement>
    {
        Task<IEnumerable<Agreement>> GetAgreementList();

        IQueryable<Object> GetDogovor();
    }
}
