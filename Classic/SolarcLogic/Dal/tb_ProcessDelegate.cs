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
    
    public partial class tb_ProcessDelegate
    {
        public int ProcessId { get; set; }
        public int DelegateId { get; set; }
        public string Observation { get; set; }
    
        public virtual tb_Delegate tb_Delegate { get; set; }
        public virtual tb_Process tb_Process { get; set; }
    }
}
