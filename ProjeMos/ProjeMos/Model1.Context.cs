﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MOSEntities : DbContext
    {
        public MOSEntities()
            : base("name=MOSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accounting> Accounting { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<Products> Products { get; set; }
    
        public virtual ObjectResult<ProductList_Result> ProductList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductList_Result>("ProductList");
        }
    }
}
