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
    
    public partial class tb_ProcessSearch
    {
        public int SearchId { get; set; }
        public int ProcessId { get; set; }
        public int ExecutedId { get; set; }
        public System.DateTime Date { get; set; }
        public int Value { get; set; }
        public string Obs { get; set; }
    
        public virtual tb_Executed tb_Executed { get; set; }
        public virtual tb_Search tb_Search { get; set; }
        public virtual tb_Process tb_Process { get; set; }
    }
}