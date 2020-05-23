using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.DTO
{
    public class SaveAgreementDTO
    {
        public int IdAgreement { get; set; }
        public int IdClient { get; set; }
        public DateTime DateAgreement { get; set; }
        public double Sum { get; set; }
    }
}
