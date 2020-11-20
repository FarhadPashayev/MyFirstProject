using MyFirstProject.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstProject.Infrastructure.Models
{
    public  class Product
    {
        public  string Name { get; set; }
        public  double Price { get; set; }
        public CategoryType  Catagory { get; set; }
       
        public  int  Count  { get; set; }
        public string  Code { get; set; }
    }
}
