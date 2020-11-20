using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstProject.Infrastructure.Models
{
    public  class Sale
    {
        public int SaleNumber  { get; set; }
        public double SaleAmount { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
