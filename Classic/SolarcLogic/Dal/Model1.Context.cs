﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_solarcDevelopEntities1 : DbContext
    {
        public db_solarcDevelopEntities1()
            : base("name=db_solarcDevelopEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<aspnet_Users> aspnet_Users { get; set; }
        public DbSet<tb_ArrangementsInPlace> tb_ArrangementsInPlace { get; set; }
        public DbSet<tb_Attachment> tb_Attachment { get; set; }
        public DbSet<tb_Court> tb_Court { get; set; }
        public DbSet<tb_Creditor> tb_Creditor { get; set; }
        public DbSet<tb_DBInfo> tb_DBInfo { get; set; }
        public DbSet<tb_Delegate> tb_Delegate { get; set; }
        public DbSet<tb_Document> tb_Document { get; set; }
        public DbSet<tb_Employer> tb_Employer { get; set; }
        public DbSet<tb_Entity> tb_Entity { get; set; }
        public DbSet<tb_Event> tb_Event { get; set; }
        public DbSet<tb_Executed> tb_Executed { get; set; }
        public DbSet<tb_ExecutedAddresses> tb_ExecutedAddresses { get; set; }
        public DbSet<tb_ExecutionType> tb_ExecutionType { get; set; }
        public DbSet<tb_ExtinctionCode> tb_ExtinctionCode { get; set; }
        public DbSet<tb_Localization> tb_Localization { get; set; }
        public DbSet<tb_Payment> tb_Payment { get; set; }
        public DbSet<tb_PaymentAgreement> tb_PaymentAgreement { get; set; }
        public DbSet<tb_PaymentType> tb_PaymentType { get; set; }
        public DbSet<tb_ProcessAttachment> tb_ProcessAttachment { get; set; }
        public DbSet<tb_ProcessDelegate> tb_ProcessDelegate { get; set; }
        public DbSet<tb_ProcessDetail> tb_ProcessDetail { get; set; }
        public DbSet<tb_ProcessEmployer> tb_ProcessEmployer { get; set; }
        public DbSet<tb_ProcessExtinction> tb_ProcessExtinction { get; set; }
        public DbSet<tb_ProcessFile> tb_ProcessFile { get; set; }
        public DbSet<tb_ProcessGInformation> tb_ProcessGInformation { get; set; }
        public DbSet<tb_ProcessGPayment> tb_ProcessGPayment { get; set; }
        public DbSet<tb_ProcessPayment> tb_ProcessPayment { get; set; }
        public DbSet<tb_ProcessRepresentativeInformation> tb_ProcessRepresentativeInformation { get; set; }
        public DbSet<tb_ProcessSearch> tb_ProcessSearch { get; set; }
        public DbSet<tb_ProcessState> tb_ProcessState { get; set; }
        public DbSet<tb_Provision> tb_Provision { get; set; }
        public DbSet<tb_ProvisionRequest> tb_ProvisionRequest { get; set; }
        public DbSet<tb_Representative> tb_Representative { get; set; }
        public DbSet<tb_Search> tb_Search { get; set; }
        public DbSet<tb_Section> tb_Section { get; set; }
        public DbSet<tb_Solicitor> tb_Solicitor { get; set; }
        public DbSet<tb_UncollectabilityCertificate> tb_UncollectabilityCertificate { get; set; }
        public DbSet<tb_ProcessGHistory> tb_ProcessGHistory { get; set; }
        public DbSet<tb_ProcessG> tb_ProcessG { get; set; }
        public DbSet<tb_Process> tb_Process { get; set; }
        public DbSet<aspnet_UsersInRoles> aspnet_UsersInRoles { get; set; }
        public DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public DbSet<tb_Calendar> tb_Calendar { get; set; }
        public DbSet<tb_ProcessClient> tb_ProcessClient { get; set; }
    }
}
