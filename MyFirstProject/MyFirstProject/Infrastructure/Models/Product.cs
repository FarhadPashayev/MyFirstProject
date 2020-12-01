using MyFirstProject.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstProject.Infrastructure.Models
{
    //Mehsul clasi yaratdig ve icine properties ler verdik
    public  class Product
    {
        public  string ProductName { get; set; }
        public  double ProductPrice { get; set; }
        public ProductCategoryType  ProductCategory { get; set; }
       
        public  int  ProductQuantity { get; set; }
        public string  ProductCode { get; set; }
    }
}
