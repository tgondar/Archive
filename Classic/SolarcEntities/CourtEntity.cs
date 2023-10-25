using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class CourtEntity
    {
        public int CourtId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime AlterDate{ get; set; }
        public string AlterUser { get; set; }
        public string JudicialDistrict { get; set; }
    }
}
