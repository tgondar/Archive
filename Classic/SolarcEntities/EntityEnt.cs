using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class EntityEnt
    {
        public int EntityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string IdentityCard { get; set; }
        public string HPhone { get; set; }
        public string MPhone { get; set; }
        public string ContactName { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string TaxNumber { get; set; }
        public string EAddress { get; set; }
        public string PostalCode { get; set; }
        public string Observation { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime AlterDate { get; set; }
        public string AlterUser { get; set; }
    }
}
