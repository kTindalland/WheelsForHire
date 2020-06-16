using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class WheelsContext : DbContext
    {
        public DbSet<Booking> Bookings_tbl { get; set; }
        public DbSet<Customer> Customers_tbl { get; set; }
        public DbSet<Equipment> Equipment_tbl { get; set; }
        public DbSet<Insurance> Insurance_tbl { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies_tbl { get; set; }
        public DbSet<Sale> Sales_tbl { get; set; }
        public DbSet<Vehicle> Vehicles_tbl { get; set; }
        public DbSet<VehicleType> VehicleTypes_tbl { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL6009.site4now.net;Initial Catalog=DB_A54212_Wheels;User Id=DB_A54212_Wheels_admin;Password=BAE12345;");
        }
    }
}
