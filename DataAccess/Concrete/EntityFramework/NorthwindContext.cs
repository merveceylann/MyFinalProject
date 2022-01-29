﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-ANT6KM3G\MS;Initial Catalog=Northwind;User ID=sa;Password=1234");
        }
        //LAPTOP-ANT6KM3G\MS
        //optionsBuilder.UseSqlServer(@"Server=\LAPTOP-ANT6KM3G\MS;Database=Northwind;User ID=sa;Password=1234;Trusted_Connection=true");
        //Data Source = LAPTOP - ANT6KM3G\MS;Initial Catalog = Northwind; User ID = sa; Password=***********
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}