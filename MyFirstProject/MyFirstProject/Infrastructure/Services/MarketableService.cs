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
        public MarketableService()
        {
            _products = new List<Product>();
            _products.Add(new Product
            {
                ProductName = "Lenova B50-50  ",
               ProductCatagory= ProductCategoryType.Computer,
                ProductPrice = 1500,
                ProductQuantity = 3,
                ProductCode = "hbxsbxsx5sx"



            });
            _products.Add(new Product
            {

                ProductName = "Samsung Note20 Ultra  ",
                ProductCatagory = ProductCategoryType.Phone,
                ProductPrice = 2500,
                ProductQuantity = 2,
                ProductCode = "hbckdjnckjdn4dc"

            });
            _products.Add(new Product
            {

                ProductName = "LG  ",
                ProductCatagory = ProductCategoryType.Tv,
                ProductPrice = 2000,
                ProductQuantity = 1,
                ProductCode = "bchdbbc51cddc"

            });

        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void AddSale(string ProductCode)
        {
            
        }

        public List<Product> EditProduct(string productCode)
        {
            return _products.FindAll(p => p.ProductCode == productCode).ToList();
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
