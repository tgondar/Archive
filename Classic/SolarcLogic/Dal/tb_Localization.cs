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
    
    public partial class tb_Localization
    {
        public tb_Localization()
        {
            this.tb_Process = new HashSet<tb_Process>();
        }
    
        public int LocalizationId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tb_Process> tb_Process { get; set; }
    }
}