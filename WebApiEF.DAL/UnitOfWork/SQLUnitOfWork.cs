using WebApiEF.DAL.Interface;
//using WebApiEF.BLL.Interface;
using WebApiEF.DAL.Repository.SQL_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;


namespace WebApiEF.DAL.UnitOfWork
{
    public class SQLUnitOfWork : IUnitOfWork
    {
        private IClientsRepository _ClientsRepository;
        private IAgreementRepository _AgreementRepository;
        private IAgreementDetailsRepository _AgreementDetailsRepository;
        private IProductsRepository _ProductsRepository;
        private EFTestContext _context;

        public SQLUnitOfWork(IClientsRepository ClientsRepository, IAgreementRepository AgreementRepository,
            IAgreementDetailsRepository AgreementDetailsRepository, IProductsRepository ProductsRepository,
        EFTestContext context)
        {
            _ClientsRepository = ClientsRepository;
            _AgreementRepository = AgreementRepository;
            _AgreementDetailsRepository = AgreementDetailsRepository;
            _ProductsRepository = ProductsRepository;
            _context = context;
        }

        public IClientsRepository ClientsRepository
        {
            get
            {
                return _ClientsRepository;
            }
        }

        public IAgreementRepository AgreementRepository
        {
            get
            {
                return _AgreementRepository;
            }
        }
        public IAgreementDetailsRepository AgreementDetailsRepository
        {
            get
            {
                return _AgreementDetailsRepository;
            }
        }
        public IProductsRepository ProductsRepository
        {
            get
            {
                return _ProductsRepository;
            }
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
