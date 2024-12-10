﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IBMClinicAutomationApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClinicDbEntities : DbContext
    {
        public ClinicDbEntities()
            : base("name=ClinicDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<advice> advices { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<chemist> chemists { get; set; }
        public virtual DbSet<drugRequest> drugRequests { get; set; }
        public virtual DbSet<drug> drugs { get; set; }
        public virtual DbSet<patientHistory> patientHistories { get; set; }
        public virtual DbSet<patientReport> patientReports { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<physician> physicians { get; set; }
        public virtual DbSet<prescription> prescriptions { get; set; }
        public virtual DbSet<PurchaseOrderDrugLine> PurchaseOrderDrugLines { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}