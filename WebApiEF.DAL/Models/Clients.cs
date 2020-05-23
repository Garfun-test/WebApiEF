using System;
using System.Collections.Generic;

namespace WebApiEF.DAL.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Agreement = new HashSet<Agreement>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Agreement> Agreement { get; set; }
    }
}
