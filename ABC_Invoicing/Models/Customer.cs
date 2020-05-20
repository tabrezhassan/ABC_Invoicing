using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC_Invoicing.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerRegNum { get; set; }
        public int CustomerVatNumber { get; set; }
        public string CustomerContact { get; set; }

    }
}