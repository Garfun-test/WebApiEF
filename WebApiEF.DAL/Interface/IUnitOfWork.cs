using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Interface;
using WebApiEF.DAL.Repository.SQL_Repository;
using WebApiEF.DAL.Models;

namespace WebApiEF.DAL.Interface
{
    public interface IUnitOfWork
    {
        IClientsRepository ClientsRepository { get; }
        
        IAgreementRepository AgreementRepository { get; }
        
        IAgreementDetailsRepository AgreementDetailsRepository { get; }
        
        IProductsRepository ProductsRepository { get; }

        Task Complete();
    }
}
