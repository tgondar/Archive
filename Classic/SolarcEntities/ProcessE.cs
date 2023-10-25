using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class ProcessE
    {
    }

    public class ProcessEClient
    {
        public int ProcessId { get; set; }
        public Guid UserId { get; set; }
        public string ClientName { get; set; }
    }
}
