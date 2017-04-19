using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MoveMe.API.Models;
using MoveMe.API.Migrations;
using System.Data.Entity.SqlServer;

namespace MoveMe.API.Data
{
    public class MoveMeDataContext : DbContext
    {
        public MoveMeDataContext() : base("MoveMe")
        {
            SqlProviderServices.SqlServerTypesAssemblyName =
                "Microsoft.SqlServer.Types, Version=13.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91";

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MoveMeDataContext, Configuration>()
            );
        }

        public IDbSet<Company> Companys { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<JobDetail> JobDetails { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<PaymentDetail> PaymentDetails { get; set; }
        public IDbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Company has many inventories and many orders 


            modelBuilder.Entity<Company>()
                .HasMany(company => company.Orders)
                .WithRequired(order => order.Company)
                .HasForeignKey(order => order.CompanyId);

            // Customer has many orders, payments, and job details

            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Orders)
                .WithRequired(order => order.Customer)
                .HasForeignKey(order => order.CustomerId);
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.PaymentDetails)
                .WithRequired(paymentDetail => paymentDetail.Customer)
                .HasForeignKey(paymentDetail => paymentDetail.CustomerId);
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.JobDetails)
                .WithRequired(jobDetail => jobDetail.Customer)
                .HasForeignKey(jobDetail => jobDetail.CustomerId);


            // Orders

            modelBuilder.Entity<Order>()
                .HasOptional(order => order.JobDetail)
                .WithOptionalDependent(jobDetail => jobDetail.Order)
                .Map(m => m.MapKey("JobDetailId")
                );

            // Payment has many Orders

            modelBuilder.Entity<PaymentDetail>()
                .HasMany(paymentDetail => paymentDetail.Orders)
                .WithRequired(order => order.PaymentDetail)
                .HasForeignKey(order => order.PaymentDetailId)
                .WillCascadeOnDelete(false);

            // User

            modelBuilder.Entity<User>()
                .HasOptional(user => user.Company)
                .WithOptionalDependent(company => company.User)
                .Map(m => m.MapKey("CompanyId"));

            modelBuilder.Entity<User>()
                .HasOptional(user => user.Customer)
                .WithOptionalDependent(customer => customer.User)
                .Map(m => m.MapKey("CustomerId"));
            modelBuilder.Entity<Order>().Ignore(o => o.JobDetailId);
        }
        //THESE STAY
        //public System.Data.Entity.DbSet<MoveMe.API.Models.Company> Companies { get; set; }

       // public System.Data.Entity.DbSet<MoveMe.API.Models.Inventory> Inventories { get; set; }
    }
}