using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.DTO
{
    public class AgreementDetailsDTO
    {
        public int IdAgreement { get; set; }
        public int IdProduct { get; set; }
        public int Number { get; set; }

    }
}
