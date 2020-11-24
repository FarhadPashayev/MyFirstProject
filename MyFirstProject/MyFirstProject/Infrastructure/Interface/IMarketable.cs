using MyFirstProject.Infrastructure.Enums;
using MyFirstProject.Infrastructure.Models;
using System;
using System.Collections.Generic;


namespace MyFirstProject.Infrastructure.Interface
{
    public interface IMarketable
    {
      List<Sale> Sales { get; }
        List<Product> Products { get; }
       void  AddSale(string ProductCode );
        int GetProductBySale( int SaleNumber , string ProductCode,int ProductQuantity );
        List<Sale> GetSales();
        List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate);
        List<Sale> GetSalesByAmountRange(double startAmount, double endAmount);
        void GetSaleByDate(DateTime Date);
        Sale GetSaleBySaleNumber(double saleNumber);
        //112320
        void AddProduct(Product product);
        void   EditProduct (string ProductCode  );
        List<Product> GetProducts();
        List<Product> GetProductsByCategoryName (ProductCategoryType productCategory );
        List<Product> GetProductsByAmountRange();
        List<Product> GetProductsByProductsName(string ProductName);
 
        


       

 

    }
}
