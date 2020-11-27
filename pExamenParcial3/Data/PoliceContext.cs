using MotorPolicy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MotorPolicy.Data
{

    public class PoliceContext: IdentityDbContext<User>{

        public PoliceContext(DbContextOptions<PoliceContext> options):base(options){

        }

        public DbSet<tblDrivers> Drivers{get;set;}
        public DbSet<tblInsuranceGroups> InsuranceGroups{get;set;}
        public DbSet<tblLink_VehiclesDrivers> link_VehiclesDrivers{get;set;}
        public DbSet<tblLink_ViolationsDrivers> link_ViolationsDrivers{get;set;}
        public DbSet<tblPolicies> Policies{get;set;}
        public DbSet<tblVehicles> Vehicles{get;set;}
        public DbSet<tblViolationCodes> ViolationCodes{get;set;}

        //api fluida

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<tblDrivers>().ToTable("Driver");
            modelBuilder.Entity<tblInsuranceGroups>().ToTable("InsuranceGroup");
            modelBuilder.Entity<tblLink_ViolationsDrivers>().ToTable("link_ViolationsDriver");
            modelBuilder.Entity<tblLink_VehiclesDrivers>().ToTable("link_VehiclesDriver");
            modelBuilder.Entity<tblPolicies>().ToTable("Policie");
            modelBuilder.Entity<tblVehicles>().ToTable("Vehicle");
            modelBuilder.Entity<tblViolationCodes>().ToTable("ViolationCode");

            modelBuilder.Entity<tblLink_ViolationsDrivers>().HasKey(j => new{j.lngDriveID,j.strViolationCode});
            modelBuilder.Entity<tblLink_VehiclesDrivers>().HasKey(j => new{j.lngDriveID,j.lngVehicleID});     

        }

    }

}