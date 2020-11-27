﻿using MyFirstProject.Infrastructure.Enums;
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
        private readonly List<SaleItem> _saleItems;
        public List<SaleItem> SaleItems =>_saleItems;

        public MarketableService()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductName = "Lenova B50-50  ",
                    ProductCategory = ProductCategoryType.Computer,
                    ProductPrice = 1500,
                    ProductQuantity = 3,
                    ProductCode = "hbxsbxsx5sx"



                },
                new Product
                {

                    ProductName = "Samsung Note20 Ultra  ",
                    ProductCategory = ProductCategoryType.Phone,
                    ProductPrice = 2500,
                    ProductQuantity = 2,
                    ProductCode = "hbckdjnckjdn4dc"

                },
                new Product
                {

                    ProductName = "LG  ",
                    ProductCategory = ProductCategoryType.Tv,
                    ProductPrice = 2000,
                    ProductQuantity = 1,
                    ProductCode = "bchdbbc51cddc"

                }
            };
            _saleItems = new List<SaleItem>
            {
                new SaleItem
                {
                    SaleCount = 3,
                    SaleItemNumber = 1,
                    SaleProduct = _products.Find(p => p.ProductCode == "hbxsbxsx5sx")
                },
                new SaleItem
                {
                    SaleCount = 2,
                    SaleItemNumber = 2,
                    SaleProduct = _products.Find(p => p.ProductCode == "hbckdjnckjdn4dc")
                },
                new SaleItem
                {
                    SaleCount = 5,
                    SaleItemNumber = 3,
                    SaleProduct = _products.Find(p => p.ProductCode == "bchdbbc51cddc")
                }
            };
            _sales = new List<Sale>
            {
                new Sale
                {
                    SaleAmount = 500,
                    SaleNumber = 1,
                    SaleDate = new DateTime(2020, 07, 25),
                    SaleItems = _saleItems.FindAll(si => si.SaleCount == 1)


                },
                new Sale
                {
                    SaleAmount = 200,
                    SaleNumber = 2,
                    SaleDate = new DateTime(2020, 08, 12),
                    SaleItems = _saleItems.FindAll(si => si.SaleCount == 2)
                },
                new Sale
                {
                    SaleAmount = 350,
                    SaleNumber = 3,
                    SaleDate = new DateTime(2020, 08, 18),
                    SaleItems = _saleItems.FindAll(si => si.SaleCount == 3)
                }
            };

        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        } //+

        public void AddSale(int code, int count)
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            double price = 0;

            var product = _products.FindAll(p => p.ProductCode.Equals(code)).FirstOrDefault();
            var saleItem = new SaleItem();
            var Code = code;
            saleItem.SaleCount = count;
            saleItem.SaleProduct = product;
            saleItem.SaleItemNumber = saleItems.Count + 1;
            saleItems.Add(saleItem);
            price += count * saleItem.SaleProduct.ProductPrice;
            var saleNo = _sales.Count + 1;
            var saleDate = DateTime.Now;
            var sale = new Sale();
            sale.SaleNumber = saleNo;
            sale.SaleAmount = price;
            sale.SaleItems = saleItems;
            sale.SaleDate = saleDate;
            _sales.Add(sale);
        } 

        public List<Product> EditProduct(string productCode)
        {
            return _products.FindAll(p => p.ProductCode == productCode).ToList();
        }  //+

        public int RemoveProductBySaleItem(int SaleNumber, string ProductCode, int ProductQuantity)
        {
            throw new NotImplementedException();
        }  //+

        public List<Product> GetProductsByAmountRange(double startAmount ,double endAmount )
        {
            return _products.Where(p => p.ProductPrice >= startAmount && p.ProductPrice <= endAmount).ToList();
        }    //+

        public void GetProductsByCategoryName(ProductCategoryType productCategory) 
        {
            List<Product> list = _products.FindAll(p => p.ProductCategory == productCategory).ToList();

            foreach (var item in list )
            {
                Console.WriteLine("{0},{1},{2}",item.ProductCode,item.ProductName,item.ProductPrice);
            }
          
        }   // +
        
        public List<Product> GetProductsByProductsName(string ProductName)
        {
            return _products.FindAll(p => p.ProductName.Contains (ProductName)).ToList();
        }          //+

        public List<Sale> GetSaleByDate(DateTime Date)
        {
           return _sales.Where(s => s.SaleDate == Date).ToList();
        } //+

        public List<Sale> GetSaleBySaleNumber(double saleNumber)
        {
            return _sales.Where(s => s.SaleNumber == saleNumber).ToList();
        } //+


        public List<Sale> GetSalesByAmountRange(double startAmount, double endAmount) 
        {
            return _sales.Where(s => s.SaleAmount >= startAmount && s.SaleAmount <= endAmount).ToList();
        } //+

        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _sales.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).ToList();
        } //+

        public void RemoveProduct(string ProductCode)
        {
            var resultlist = _products.ToList();
            var itemToRemove = resultlist.Single(r => r.ProductCode == ProductCode);
            _products.Remove(itemToRemove);
        }          //+

        public void RemoveSale(int saleNumber)
        {
            Sale sale = _sales.Find(s => s.SaleNumber == saleNumber);
            _sales.Remove(sale);
        } //+

        public List<SaleItem> ShowSaleItem(int saleNumber)
        {
            return _sales.Find(s => s.SaleNumber == saleNumber).SaleItems.ToList();
        } //+
    }
}
