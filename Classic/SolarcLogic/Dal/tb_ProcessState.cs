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
    
    public partial class tb_ProcessState
    {
        public tb_ProcessState()
        {
            this.tb_ProcessDetail = new HashSet<tb_ProcessDetail>();
        }
    
        public int ProcessStateId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tb_ProcessDetail> tb_ProcessDetail { get; set; }
    }
}