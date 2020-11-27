﻿using MyFirstProject.Infrastructure.Enums;
using MyFirstProject.Infrastructure.Models;
using System;
using System.Collections.Generic;


namespace MyFirstProject.Infrastructure.Interface
{
    public interface IMarketable
    {
      List<Sale> Sales { get; }
        List<Product> Products { get; }
        List<SaleItem> SaleItems { get; }
       void  AddSale(Sale sale );
        List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate);
        List<Sale> GetSalesByAmountRange(double startAmount, double endAmount);
        List<Sale> GetSaleByDate(DateTime Date);
        List<Sale> GetSaleBySaleNumber(double saleNumber);
        void RemoveSale(int saleNumber);
        List<SaleItem> ShowSaleItem(int saleNumber);

        //112320
        void AddProduct(Product product);
        List<Product>  EditProduct (string ProductCode  );
        int RemoveProductBySaleItem(int SaleNumber, string ProductCode, int ProductQuantity);
        void GetProductsByCategoryName (ProductCategoryType productCategory );
        List<Product> GetProductsByAmountRange(double startAmount , double endAmount );
        List<Product> GetProductsByProductsName(string ProductName);
        void RemoveProduct(string ProductCode);

        


       

 

    }
}
