//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjeMos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accounting
    {
        public int AccountingID { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<int> ProductID { get; set; }
    
        public virtual Products Products { get; set; }
    }
}
