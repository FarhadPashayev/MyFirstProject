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
        private string productName;

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
                ProductName = "AAA",
                ProductPrice = 25,
                ProductQuantity = 70,
                ProductCode = "IN000021456"
            });

            _products.Add(new Product
            {
                ProductCategory = ProductCategoryType.Phone,
                ProductName = "IPhone 12 Mini 64GB Blue",
                ProductPrice = 1500,
                ProductQuantity = 5,
                ProductCode = "IN000021939"
            });

            _products.Add(new Product
            {
                ProductCategory = ProductCategoryType.Tv,
                ProductName = "Zimmer ZM-TVH3235",
                ProductPrice = 600,
                ProductQuantity = 10,
                ProductCode = "IN000015880"
            });
            _products.Add(new Product
            {
                ProductCategory = ProductCategoryType.Computer,
                ProductName = "Lenova B50-50",
                ProductPrice = 1200,
                ProductQuantity = 10,
                ProductCode = "IN000015999"

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
            _saleItems.Add(new SaleItem
            {
                SaleItemNumber = 4,
                SaleCount = 4,
                SaleProduct = _products.Find(p => p.ProductCode == "IN000015999")

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
                SaleItems = _saleItems.FindAll(si => si.SaleItemNumber == 3)
            });
            _sales.Add(new Sale
            {
                SaleNumber = 4,
                SaleAmount = 22,
                SaleDate = new DateTime(2020, 10, 27),
                SaleItems = _saleItems.FindAll(si => si.SaleItemNumber == 4)

            });
            #endregion
        }
        #region Product Method
        // AddProduct un isdediyi parametr yazdig 
        public void AddProduct(Product product)
        {
            _products.Add(product);
        } //+
        //Edit Produc bizden parametr olarig string cinsinden productCode isdiyirdi 
        public List<Product> EditProduct(string productCode)
        {
            return _products.FindAll(p => p.ProductCode == productCode).ToList();
        }  //+
        //GetProductsByAmountRange bizden qiymet araligini gosdermey ucun her ikisi double cinsinden olan start ve end amount isdiyirdi 
        public List<Product> GetProductsByAmountRange(double startAmount ,double endAmount )
        {
            return _products.Where(p => p.ProductPrice >= startAmount && p.ProductPrice <= endAmount).ToList();
        }    //+
        //GetProductsByCategoryName parametr olarig ProductCategoryType cinsinden productCategory isdiyir 
        public void GetProductsByCategoryName(ProductCategoryType productCategory) 
        {
            List<Product> list = _products.FindAll(p => p.ProductCategory == productCategory).ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Bu kateqoriyada məhsul yoxdur!");
            }
            else
            {


                foreach (var item in list)
                {
                    Console.WriteLine("{0},{1},{2}", item.ProductCode, item.ProductName, item.ProductPrice);
                }
            }
          
        }   // +
        //GetProductsByProductsName productun adina gore mehsulu cixardmag ucun ucun bizden parametr olarag string cinsinden ProductName isdiyir 
        public List<Product> GetProductsByProductsName(string ProductName)
        {
           
            var list = _products.Where(p => p.ProductName.Contains(ProductName)).ToList();

            return list;


        }          //+
        //RemoveProduct productu silmek ucun biz parametr olarag biz string cinsinden productCode veririk ki code daxil edende silsin productu  
        public void RemoveProduct(string productCode)
        {

            var resultlist = _products.ToList();
            bool check = _products.Exists(p => p.ProductCode == productCode);
            if (check == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Bu koda görə məhsul tapılmadı!");
            }
            else
            {
                var itemToRemove = resultlist.Single(r => r.ProductCode == productCode);

                _products.Remove(itemToRemove);

                Console.WriteLine("");
                Console.WriteLine("-------------- Məhsul silindi --------------");
            }

        }    //+
        #endregion


        #region Sale Method 
        // AddSale satis elave etmek ucun biz parametr vermeliyik string cinsinden productCode ve int cinsinden productQuantity
        public void AddSale(string productCode, int productQuantity)
        {

            List<SaleItem> saleItems = new List<SaleItem>();
            double amount = 0;

            var product = _products.Where(p => p.ProductCode == productCode).FirstOrDefault();
            var saleItem = new SaleItem();
            var Code = productCode;

            bool check = _products.Exists(p => p.ProductCode == productCode);
            if (check == false)
            {
                Console.WriteLine("");
                Console.WriteLine("-------------- Daxil etdiyiniz koda görə məhsul tapılmadı --------------");
            }
            else
            {
                saleItem.SaleCount = productQuantity;
                if (product.ProductQuantity < productQuantity)
                {
                    Console.WriteLine("");
                    Console.WriteLine("-------------- Daxil etdiyiniz miqdarda məhsul yoxdur --------------");
                    Console.WriteLine("");
                }
                else
                {
                    product.ProductQuantity -= productQuantity;
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

                    _sales.Add(sale);

                    Console.WriteLine("");
                    Console.WriteLine("-------------- Yeni Satış əlavə edildi --------------");
                    Console.WriteLine("");
                }
            }

        }  //+
        // GetSaleByDate bu method bir zamanda olan satislari gosderir ve gosdermesi ucun parametr veririk datetime cinsinden date 
        public List<Sale> GetSaleByDate(DateTime Date)
        {
           return _sales.Where(s => s.SaleDate == Date).ToList();
        } //+
        // GetSaleBySaleNumber verilmis nomreye esasen hemin nomreli satisin gosderilmesi bunun ucun biz parametr olarag double cinsinden saleNumber vermeliyik
        public List<Sale> GetSaleBySaleNumber(double saleNumber)
        {
            return _sales.Where(s => s.SaleNumber == saleNumber).ToList();
        } //+

        //GetSalesByAmountRange qiymet araligina gore satislarin gosderilmesi bu method ucunde double cinsinden start ve end amount veririk ki bize gosdersin 
        public List<Sale> GetSalesByAmountRange(double startAmount, double endAmount) 
        {
            return _sales.Where(s => s.SaleAmount >= startAmount && s.SaleAmount <= endAmount).ToList();
        } //+
        // GetSalesByDateRange bu method zaman araligina gore satislari gosderir ve biz parametr olarig datetime cinsinden start ve end date veririk 
        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _sales.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).ToList();
        } //+


        // RemoveSale satisin silinmesi isini gorur parametr olarag int cinsinden saleNumber veririk satisin nomresine gore silsin 
        public void RemoveSale(int saleNumber)
        {
            bool check = _sales.Exists(s => s.SaleNumber == saleNumber);
            if (check == false)
            {
                Console.WriteLine("");
                Console.WriteLine("{0} nömrəli satış yoxdur!", saleNumber);
            }
            else
            {
                Sale sale = _sales.Find(s => s.SaleNumber == saleNumber);
                _sales.Remove(sale);

                Console.WriteLine("");
                Console.WriteLine("============== Satış silindi ==============");
            }
        } //+
        //ShowSaleItem  
        public List<SaleItem> ShowSaleItem(int saleNumber)
        {
            return _sales.Find(s => s.SaleNumber == saleNumber).SaleItems.ToList();
        } //+
        //RemoveProductBySaleItem satisin satisda hansisa mehsulun geri qaytarilmasi parametr olarag int cinsinden bizden saleNumber string cinsinden productCode int cinsinden productQuantity isdiyir 
        public double RemoveProductBySaleItem(int saleNumber, string productCode, int productQuantity)
        {
            double amount = 0;
            var prolist = _products.ToList();
            var salelist = _sales.ToList();


            
            bool checkSaleNumber = _sales.Exists(s => s.SaleNumber == saleNumber);
            if (checkSaleNumber == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Bu nömrədə satış yoxdur!");
            }
            else
            {
                var sale = salelist.Find(r => r.SaleNumber == saleNumber);
                bool checkProductCode = prolist.Exists(p => p.ProductCode == productCode);
                if (checkProductCode == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Bu koda aid məhsul tapılmadı!");
                }
                else
                {



                    var list = prolist.Find(r => r.ProductCode == productCode);
                    if (sale.SaleAmount > list.ProductPrice * productQuantity)
                    {
                        sale.SaleAmount -= list.ProductPrice * productQuantity;

                    }
                    else if ((sale.SaleAmount == list.ProductPrice * productQuantity))
                    {
                        _sales.Remove(sale);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Kodu {0} olan məhsuldan {1} sayda satılmayıb!\n\nDüzgün say daxil edin!", productCode, productQuantity);
                    }
                }
            }
            return amount;
        }
        #endregion
    }
}
