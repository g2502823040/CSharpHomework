﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class OrderSQL : DbContext
    {
        public OrderSQL() : base("OrderDataBase")
        {
        }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
}
