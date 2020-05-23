using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Interface;
using WebApiEF.DAL.Models;

namespace WebApiEF.DAL.Repository.SQL_Repository
{
    public class AgreementDetailsRepository : GenericRepository<AgreementDetails>, IAgreementDetailsRepository
    {
        public AgreementDetailsRepository(EFTestContext context) : base(context)
        {

        }
    }
}
