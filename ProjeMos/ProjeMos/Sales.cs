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
    
    public partial class Sales
    {
        public int SalesID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string CategoryName { get; set; }
        public string Quantity { get; set; }
        public Nullable<int> Stock { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SellPrice { get; set; }
        public Nullable<int> SepetID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> Hour { get; set; }
        public string ProductName { get; set; }
    }
}
