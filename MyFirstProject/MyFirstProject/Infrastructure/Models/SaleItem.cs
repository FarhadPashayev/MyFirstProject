﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstProject.Infrastructure.Models
{
     public  class SaleItem
    {
        public int SaleItemNumber { get; set; }
        public Product SaleProduct { get; set; }
        public int SaleCount { get; set; }

    }
}
