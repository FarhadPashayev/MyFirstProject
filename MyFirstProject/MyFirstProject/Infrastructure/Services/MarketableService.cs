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
        private readonly List<Sale> _sales;
        public List<Sale> Sales => _sales;
        private readonly List<Product> _products;
        public List<Product> Products => _products;

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void AddSale(string ProductCode)
        {
            
        }

        public void EditProduct(string ProductCode)
        {
            throw new NotImplementedException();
        }

        public int GetProductBySale(int SaleNumber, string ProductCode, int ProductQuantity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByAmountRange()
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

        public Sale GetSaleBySaleNumber(double saleNumber)
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
