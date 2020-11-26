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
        int RemoveProductBySaleItem( int SaleNumber , string ProductCode,int ProductQuantity );
        List<Sale> GetSales();
        List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate);
        List<Sale> GetSalesByAmountRange(double startAmount, double endAmount);
        void GetSaleByDate(DateTime Date);
        Sale GetSaleBySaleNumber(double saleNumber);
        //112320
        void AddProduct(Product product);
        List<Product>  EditProduct (string ProductCode  );
        void GetProductsByCategoryName (ProductCategoryType productCategory );
        List<Product> GetProductsByAmountRange(double startAmount , double endAmount );
        List<Product> GetProductsByProductsName(string ProductName);
        void RemoveProduct(string ProductCode);
 
        


       

 

    }
}
