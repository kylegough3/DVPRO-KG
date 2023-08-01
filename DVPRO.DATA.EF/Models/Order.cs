﻿using System;
using System.Collections.Generic;

namespace DVPRO.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public string? Ponumber { get; set; }
        public int VendorId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? OrderTotal { get; set; }

        //Allowed virtual vendor to allow nulls in order to use the create action
        public virtual Vendor? Vendor { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
