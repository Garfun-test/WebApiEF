using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF;
using WebApiEF.BLL.DTO;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Clients, ClientsDTO>();
            CreateMap<ClientsDTO, Clients>();
            CreateMap<Agreement, AgreementDTO>();
            CreateMap<AgreementDTO, Agreement>();
            CreateMap<AgreementDetails, AgreementDetailsDTO>();
            CreateMap<AgreementDetailsDTO, AgreementDetails>();
            CreateMap<Products, ProductsDTO>();
            CreateMap<ProductsDTO, Products>();
            CreateMap<SaveAgreementDTO, Agreement>();
        }
    }
}