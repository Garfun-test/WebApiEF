using System;
using System.Collections.Generic;

namespace WebApiEF.DAL.Models
{
    public partial class AgreementDetails
    {
        public int IdAgreement { get; set; }
        public int IdProduct { get; set; }
        public int Number { get; set; }

        public virtual Agreement IdAgreementNavigation { get; set; }
        public virtual Products IdProductNavigation { get; set; }
    }
}
