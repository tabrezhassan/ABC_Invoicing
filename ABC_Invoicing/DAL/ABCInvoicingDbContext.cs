using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ABC_Invoicing.Models;

namespace ABC_Invoicing.DAL
{
    public class ABCInvoicingDbContext : DbContext
    {
        public ABCInvoicingDbContext() : base("ABCInvoicingConnectionString")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}