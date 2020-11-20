using MyFirstProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstProject.Infrastructure.Interface
{
    public interface IMarketable
    {
      List<Sale> Sales { get; }
        List<Product> Products { get; }
       void  AddSale(string ProductCode );
        void GetProductBySale(string Name ,int Count  );
        void RemoveSale(int SaleNumber );
        List<Sale> GetSales();
        void GetSalesByDateRange(DateTime startDate, DateTime endDate);
        void GetSalesByAmountRange(double startAmount, double endAmount);
        void GetSaleByDate(DateTime Date);
        void GetSaleBySaleNumber(double saleNumber);
       

 

    }
}
