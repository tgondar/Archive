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
    
    public partial class tb_ProcessGHistory
    {
        public int Id { get; set; }
        public int ProcessGId { get; set; }
        public string Field { get; set; }
        public string FromValue { get; set; }
        public string ToValue { get; set; }
        public string AlterUser { get; set; }
        public System.DateTime AlterDate { get; set; }
    
        public virtual tb_ProcessG tb_ProcessG { get; set; }
    }
}
