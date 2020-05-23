using System;
using System.Collections.Generic;

namespace WebApiEF.DAL.Models
{
    public partial class Products
    {
        public Products()
        {
            AgreementDetails = new HashSet<AgreementDetails>();
        }

        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public double PriceRetail { get; set; }
        public double PriceWholesale { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AgreementDetails> AgreementDetails { get; set; }
    }
}
