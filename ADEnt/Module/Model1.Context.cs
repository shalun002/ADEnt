﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADEnt.Module
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MCSEntities1 : DbContext
    {
        public MCSEntities1()
            : base("name=MCSEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<newEquipment> newEquipments { get; set; }
        public virtual DbSet<TablesLocation> TablesLocations { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturers { get; set; }
        public virtual DbSet<TablesModel> TablesModels { get; set; }
        public virtual DbSet<TablesSNPrefix> TablesSNPrefixes { get; set; }
    }
}