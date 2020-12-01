using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstProject.Infrastructure.Models
{
    //satis item yaradib icine propertiesler verdik
     public  class SaleItem
    {
        public int SaleItemNumber { get; set; }
        public Product SaleProduct { get; set; }
        public int SaleCount { get; set; }

    }
}
