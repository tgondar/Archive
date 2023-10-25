using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class ProcessGInformationEntity
    {
        public int ProcessGId { get; set; }
        public int InformationId { get; set; }
        public string Information { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
    }
}
