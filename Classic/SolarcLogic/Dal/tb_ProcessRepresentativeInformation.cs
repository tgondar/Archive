//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SolarcLogic.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_ProcessRepresentativeInformation
    {
        public int ProcessId { get; set; }
        public int RepresentativeId { get; set; }
        public System.DateTime Date { get; set; }
        public string Information { get; set; }
        public string CreateUser { get; set; }
    
        public virtual tb_Representative tb_Representative { get; set; }
        public virtual tb_Process tb_Process { get; set; }
    }
}
