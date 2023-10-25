using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class ProcessGHistoryEntity
    {
        public int Id { get; set; }
        public int ProcessGId { get; set; }
        public string Field { get; set; }
        public string FromValue { get; set; }
        public string ToValue { get; set; }
        public string AlterUser { get; set; }
        public DateTime AlterDate { get; set; }

        public string ProcessCode { get; set; }
    }
}
