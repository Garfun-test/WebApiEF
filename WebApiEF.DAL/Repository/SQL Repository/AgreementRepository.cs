using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Interface;
using WebApiEF.DAL.Models;

namespace WebApiEF.DAL.Repository.SQL_Repository
{
    public class AgreementRepository : GenericRepository<Agreement>, IAgreementRepository
    {
        public AgreementRepository(EFTestContext context) : base(context)
        {  }


        public IQueryable<Object> GetDogovor()
        {
            return from a in _context.Set<Agreement>()
                   join c in _context.Set<Clients>() on a.IdClient equals c.IdClient
                   join ad in _context.Set<AgreementDetails>() on a.IdAgreement equals ad.IdAgreement
                   join p in _context.Set<Products>() on ad.IdProduct equals p.IdProduct
                   orderby a.IdAgreement
                   select new
                   {
                       AgreementNumber = a.IdAgreement,
                       NameClient = c.Name,
                       PersonClient = c.ContactPerson,
                       NumberProduct = ad.Number,
                       ProductName = p.NameProduct,
                       Adreementdate = a.DateAgreement

                   };

        }


        public async Task<IEnumerable<Agreement>> GetAgreementList()
        {
            var agreements = await _context
                .Set<Agreement>()
                .Include(p => p.Clients)
                .ToListAsync();

            return agreements;
        }
    }
}
