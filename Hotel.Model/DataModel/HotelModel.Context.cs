﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel.Model.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HOTELEntities : DbContext
    {
        public HOTELEntities()
            : base("name=HOTELEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Calisan> Calisan { get; set; }
        public virtual DbSet<EkHizmet> EkHizmet { get; set; }
        public virtual DbSet<Fiyat> Fiyat { get; set; }
        public virtual DbSet<Il> Il { get; set; }
        public virtual DbSet<Ilce> Ilce { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Oda> Oda { get; set; }
        public virtual DbSet<Oda_EkHizmet> Oda_EkHizmet { get; set; }
        public virtual DbSet<OdaTipi> OdaTipi { get; set; }
        public virtual DbSet<Otel> Otel { get; set; }
        public virtual DbSet<Otel_Calisan> Otel_Calisan { get; set; }
        public virtual DbSet<Otel_OtelOlanaklari> Otel_OtelOlanaklari { get; set; }
        public virtual DbSet<OtelOlanaklari> OtelOlanaklari { get; set; }
        public virtual DbSet<Rezervasyon> Rezervasyon { get; set; }
        public virtual DbSet<Rezervasyon_EkHizmet> Rezervasyon_EkHizmet { get; set; }
        public virtual DbSet<Rezervasyon_Musteri> Rezervasyon_Musteri { get; set; }
        public virtual DbSet<Rezervasyon_Oda> Rezervasyon_Oda { get; set; }
        public virtual DbSet<Rezervasyon_OtelOlanaklari> Rezervasyon_OtelOlanaklari { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
