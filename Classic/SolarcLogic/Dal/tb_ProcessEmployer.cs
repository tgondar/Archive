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
    
    public partial class tb_ProcessEmployer
    {
        public int EmployerId { get; set; }
        public int ExecutedId { get; set; }
        public int ProcessId { get; set; }
    
        public virtual tb_Employer tb_Employer { get; set; }
        public virtual tb_Executed tb_Executed { get; set; }
        public virtual tb_Process tb_Process { get; set; }
    }
}
