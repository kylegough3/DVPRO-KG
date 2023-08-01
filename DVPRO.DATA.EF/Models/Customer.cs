﻿using System;
using System.Collections.Generic;

namespace DVPRO.DATA.EF.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string ContactName { get; set; } = null!;
        public string ContactPhone { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string BillingAddress { get; set; } = null!;
        public string BillingCity { get; set; } = null!;
        public string? BillingState { get; set; }
        public string? BillingPostalCode { get; set; }
        public int CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
