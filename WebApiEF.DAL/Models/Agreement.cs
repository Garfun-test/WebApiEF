using System;
using System.Collections.Generic;

namespace WebApiEF.DAL.Models
{
    public partial class Agreement
    {
        public int IdAgreement { get; set; }
        public DateTime DateAgreement { get; set; }
        public double Sum { get; set; }

        public Clients Clients { get; set; }
        public int IdClient { get; set; }

        public ICollection<AgreementDetails> AgreementDetails { get; set; }
        
    }
}
