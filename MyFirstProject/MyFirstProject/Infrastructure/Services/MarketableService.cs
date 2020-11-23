using MyFirstProject.Infrastructure.Enums;
using MyFirstProject.Infrastructure.Interface;
using MyFirstProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstProject.Infrastructure.Services
{
    public class MarketableService : IMarketable
    {
        public List<Sale> Sales => throw new NotImplementedException();

        public List<Product> Products => throw new NotImplementedException();

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void AddSale(string ProductCode)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(string ProductCode)
        {
            throw new NotImplementedException();
        }


        public void GetProductBySale(int SaleNumber, string ProductCode, int Count)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByAmountRange(double startAmount, double endAmount)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategoryName(ProductCategoryType productCategory)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByProductsName(string ProductName)
        {
            throw new NotImplementedException();
        }

        public void GetSaleByDate(DateTime Date)
        {
            throw new NotImplementedException();
        }

        public void GetSaleBySaleNumber(double saleNumber)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSales()
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesByAmountRange(double startAmount, double endAmount)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

       
    }
}
