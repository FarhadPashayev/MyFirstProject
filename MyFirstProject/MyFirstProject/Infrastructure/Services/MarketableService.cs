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
        private readonly List<SaleItem> _saleItems;
        public List<SaleItem> SaleItems =>_saleItems;

        public MarketableService()
        {
            _sales = new List<Sale>();
            _saleItems = new List<SaleItem>();
            _products = new List<Product>();

            #region Default Product
            _products.Add(new Product
            {
                ProductCategory = ProductCategoryType.SonyHeadphone,
                ProductName = "Sony qulaqlıq",
                ProductPrice = 25,
                ProductQuantity = 70,
                ProductCode = "IN000021456"
            });

            _products.Add(new Product
            {
                ProductCategory = ProductCategoryType.Phone,
                ProductName = "Telefon iPhone 12 Mini 64GB Blue",
                ProductPrice = 1500,
                ProductQuantity = 5,
                ProductCode = "IN000021939"
            });

            _products.Add(new Product
            {
                ProductCategory = ProductCategoryType.SonyHeadphone,
                ProductName = "Sony qulaqlıq pro",
                ProductPrice = 50,
                ProductQuantity = 10,
                ProductCode = "IN000015880"
            });
            #endregion

            #region Default SaleItem
            _saleItems.Add(new SaleItem
            {
                SaleItemNumber = 1,
                SaleCount = 1,
                SaleProduct = _products.Find(p => p.ProductCode == "IN000021456")

            });

            _saleItems.Add(new SaleItem
            {
                SaleItemNumber = 2,
                SaleCount = 2,
                SaleProduct = _products.Find(p => p.ProductCode == "IN000021939")

            });

            _saleItems.Add(new SaleItem
            {
                SaleItemNumber = 3,
                SaleCount = 3,
                SaleProduct = _products.Find(p => p.ProductCode == "IN000015880")

            });
            #endregion

            #region Default Sale
            _sales.Add(new Sale
            {
                SaleNumber = 1,
                SaleAmount = 25,
                SaleDate = new DateTime(2020, 5, 16),
                SaleItems = _saleItems.FindAll(si => si.SaleItemNumber == 1)
            });

            _sales.Add(new Sale
            {
                SaleNumber = 2,
                SaleAmount = 80,
                SaleDate = new DateTime(2020, 8, 19),
                SaleItems = _saleItems.FindAll(si => si.SaleItemNumber == 2)
            });

            _sales.Add(new Sale
            {
                SaleNumber = 3,
                SaleAmount = 30,
                SaleDate = new DateTime(2020, 11, 27),
                SaleItems = _saleItems.FindAll(si => si.SaleItemNumber == 2)
            });
            #endregion
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        } //+

        public void AddSale(string productCode, int productQuantity)
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            double amount = 0;

            var product = _products.Where(p => p.ProductCode.Equals(productCode)).FirstOrDefault();
            var saleItem = new SaleItem();
            var Code = productCode;
            saleItem.SaleCount =productQuantity;
            saleItem.SaleProduct = product;
            saleItem.SaleItemNumber = saleItems.Count + 1;
            saleItems.Add(saleItem);
            amount += productQuantity * saleItem.SaleProduct.ProductPrice;
            var saleNumber = _sales.Count + 1;
            var saleDate = DateTime.Now;
            var sale = new Sale();
            sale.SaleNumber = saleNumber;
            sale.SaleAmount = amount;
            sale.SaleDate = saleDate;
            sale.SaleItems = saleItems;
            _sales.Add(sale);
        }  //+

        public List<Product> EditProduct(string productCode)
        {
            return _products.FindAll(p => p.ProductCode == productCode).ToList();
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
        }    //+

        public void RemoveSale(int saleNumber)
        {
            Sale sale = _sales.Find(s => s.SaleNumber == saleNumber);
            _sales.Remove(sale);
        } //+

        public List<SaleItem> ShowSaleItem(int saleNumber)
        {
            return _sales.Find(s => s.SaleNumber == saleNumber).SaleItems.ToList();
        } //+

        public double RemoveProductBySaleItem(int saleNumber, string productCode, int quantity)
        {
            double amount = 0;
            var prolist = _products.ToList();
            var salelist = _sales.ToList();


            var sale = salelist.Find(r => r.SaleNumber == saleNumber);


            bool findproduct = prolist.Exists(r => r.ProductCode == productCode);
            if (findproduct == true)
            {
                var list = prolist.Find(r => r.ProductCode == productCode);
                if (sale.SaleAmount > list.ProductPrice * quantity)
                {
                    sale.SaleAmount -= list.ProductPrice * quantity;

                }
                else if ((sale.SaleAmount == list.ProductPrice * quantity))
                {
                    _sales.Remove(sale);
                }
            }
            return amount;
        }
    }
}
