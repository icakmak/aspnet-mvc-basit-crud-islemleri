﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc_Ogrenci_kayit.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OgrenciEntities : DbContext
    {
        public OgrenciEntities()
            : base("name=OgrenciEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_Ogrenci> TBL_Ogrenci { get; set; }
        public virtual DbSet<TBL_Dersler> TBL_Dersler { get; set; }
    }
}
