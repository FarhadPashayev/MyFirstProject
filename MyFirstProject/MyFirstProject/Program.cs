using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTables;
using MyFirstProject.Infrastructure.Enums;
using MyFirstProject.Infrastructure.Models;
using MyFirstProject.Infrastructure.Services;

namespace MyFirstProject
{
    class Program
    {
        private static readonly MarketableService _marketableService = new MarketableService();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int selectInt;
            do
            {
                #region First Menu
                Console.WriteLine("=========Market idare etmək sistemi========== ");
                Console.WriteLine("1. Məhsullar üzərində əməliyyat aparmaq ");
                Console.WriteLine("2. Satışlar üzərində əməliyyat aparmaq ");
                Console.WriteLine("0. sistemdən çıxmaq ");
                #endregion
                #region First Menu Selection 
                Console.WriteLine("seçiminiz edin: ");
                string select = Console.ReadLine();
                while (!int.TryParse(select, out selectInt))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz!");
                    select = Console.ReadLine();
                }
                #endregion

                #region Menu Swicth
                switch (selectInt)
                {
                    case 0:
                        continue;
                    case 1:
                        ShowProductsMenu();
                        break;
                    case 2:
                        ShowSale();
                        break;

                    default:
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("==========Siz yanlış seçim etdiniz 0-2 arası seçim edə bilərsiz =========== ");
                        Console.WriteLine("----------------------------------");
                        break;
                }

                #endregion


            } while (selectInt != 0);
            // Mehsul isdediklerini gosdermey ucun 
            static void ShowProductsMenu()

            #region second Menu 
            {
                int SelectInt1;
                do
                {
                    Console.WriteLine("===================Məhsullar üzərində əməliyyat aparmaq===================");
                    Console.WriteLine("1. Yeni məhsul əlavə et ");
                    Console.WriteLine("2. Məhsul üzərində düzəliş et ");
                    Console.WriteLine("3. Məhsulu sil");
                    Console.WriteLine("4. Bütün məhsulları göstər ");
                    Console.WriteLine("5. Kateqoriyasına görə məhsulları göstər");
                    Console.WriteLine("6. Qiymət aralığına görə məhsulları göstər ");
                    Console.WriteLine("7. Məhsullar arasında ada görə axtarış et ");
                    #endregion

                    #region Second Menu Selections

                    string Select = Console.ReadLine();
                    while (!int.TryParse(Select, out SelectInt1))
                    {
                        Console.WriteLine("Rəqəm daxil etməlisiniz");
                        Select = Console.ReadLine();
                    }


                    #endregion

                    #region second Menu Switch
                    switch (SelectInt1)
                    {
                        case 1:
                            ShowProductAdd();
                            break;
                        case 2:
                            ShowProductEdit();
                            break;
                        case 3:
                            ShowRemoveProduct();
                            break;
                        case 4:
                            ShowProductList();
                            break;
                        case 5:
                            ShowGetProductsByCategoryName();
                            break;
                        case 6:
                            ShowGetProductByAmountRange();
                            break;
                        case 7:
                            ShowGetProductsByProductsName();
                            break;
                        default:
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("siz yalnış seçim etdiniz,1-7 arasında seçim edin ");
                            Console.WriteLine("----------------------------------------------------");
                            break;
                    }



                    #endregion


                } while (SelectInt1 != 0);

            }

            //satis isdeklerni gosdermek ucun 
            static void ShowSale()
            #region Three  Menu 
            {
                int SelectInt2;
                do
                {

                    Console.WriteLine("--------------Satışlar üzərində əməliyyat aparmaq----------------");
                    Console.WriteLine("1. Yeni satış əlavə etmək ");
                    Console.WriteLine("2. Satışdan hansısa məhsulun geri qaytarılması");
                    Console.WriteLine("3. Satışın silinməsi ");
                    Console.WriteLine("4. Bütün satışların ekrana çıxarılması");
                    Console.WriteLine("5. Verilən tarix aralığına görə satışların göstərilməsi ");
                    Console.WriteLine("6. Verilən məbləğ aralığına görə satışların göstərilməsi ");
                    Console.WriteLine("7. Verilmiş bir tarixdə olan satışların göstərilməsi");
                    Console.WriteLine("8. Verilmiş nömrəyə əsasən həmin nömrəli satışın məlumatlarının göstərilməsi ");
                    #endregion
                    #region Three Menu Selections
                    string Select = Console.ReadLine();
                    while (!int.TryParse(Select, out SelectInt2))
                    {
                        Console.WriteLine("Rəqəm daxil etməlisiniz");
                        Select = Console.ReadLine();
                    }

                    #endregion
                    #region Three Menu Switch
                    switch (SelectInt2)
                    {
                        case 1:
                            ShowAddSale();
                            break;
                        case 2:
                            ShowRemoveProductBySaleItem();
                            break;
                        case 3:
                            ShowRemoveSale();
                            break;
                        case 4:
                            ShowSaleList();
                            break;
                        case 5:
                            ShowGetSalesByDateRange();
                            break;
                        case 6:
                            ShowGetSalesByAmountRange();
                            break;
                        case 7:
                            ShowGetSaleByDate();
                            break;
                        case 8:
                            ShowGetSaleBySaleNumber();
                            break;
                        default:
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("siz yalnış seçim etdiniz,1-8 arasında seçim edin ");
                            Console.WriteLine("----------------------------------------------------");
                            break;
                    }


                    #endregion


                } while (SelectInt2 != 0);




            }
            // Table methodu  
           
            static void ShowProductList()
            {
                Console.WriteLine("-------------- Mövcud məhsullar --------------");

                var table = new ConsoleTable("No", "Kateqoriya", "Məhsul", "Sayı", "Qiyməti", "Məhsul Kodu");
                int i = 1;
                
                foreach (var item in _marketableService.Products)
                {
                    table.AddRow(i, item.ProductCategory, item.ProductName, item.ProductQuantity, item.ProductPrice, item.ProductCode);
                    i++;
                }

                table.Write();
            }
           
            // Add product methodu yaradag 
            static void ShowProductAdd()
            {
                Console.WriteLine("===================== Yeni satış əlavə et =====================");
                Product product = new Product();

                #region ProductCategoryType 
                int selectInt;
                do
                {
                    #region product Category Menu
                    Console.WriteLine("Kategoriya daxil edin :");
                    Console.WriteLine("1. SonyHeadphone ");
                    Console.WriteLine("2. Tv");
                    Console.WriteLine("3. Computer");
                    Console.WriteLine("4. Phone");
                    #endregion

                    #region Product Category Selection
                    Console.WriteLine("");
                    Console.Write("Seçiminizi edin:");
                    string select = Console.ReadLine();

                    while (!int.TryParse(select, out selectInt))
                    {
                        Console.WriteLine("");
                        Console.Write("Rəqəm daxil etməlisiniz!: ");
                        select = Console.ReadLine();
                    }
                    #endregion
                    #region Product Category switch 
                    switch (selectInt)
                    {
                        case 1:
                            product.ProductCategory = ProductCategoryType.SonyHeadphone;
                            break;
                        case 2:
                            product.ProductCategory = ProductCategoryType.Tv;
                            break;
                        case 3:
                            product.ProductCategory = ProductCategoryType.Computer;
                            break;
                        case 4:
                            product.ProductCategory = ProductCategoryType.Phone;
                            break;
                        default:
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("Siz yalnış seçim etdiniz, 1-4 aralığında seçim etməlisiniz! ");
                            Console.WriteLine("-----------------------------------------------");
                            break;

                    }
                    #endregion

                } while (selectInt == 0);

                #endregion

                #region ProductName

                Console.Write("Məhsulun adını daxil edin :");
                product.ProductName = Console.ReadLine();
                #endregion

                #region ProductPrice 

                Console.Write("Satışın qiymətini daxil edin :");
                string ProductPriceInput = Console.ReadLine();
                double ProductPrice;
                while (!double.TryParse(ProductPriceInput, out ProductPrice))
                {
                    Console.Write("Ancaq rəqəm daxil etməlisiniz :");
                    ProductPriceInput = Console.ReadLine();
                }
                product.ProductPrice = ProductPrice;
                #endregion

                #region ProductQuantity 

                Console.Write("Satış sayını daxil edin :");
                string ProductQuantityInput = Console.ReadLine();
                int ProductQuantity;
                while (!int.TryParse(ProductQuantityInput, out ProductQuantity))
                {
                    Console.Write("Rəqəm daxil etməlisiniz!");
                    ProductQuantityInput = Console.ReadLine();
                }
                product.ProductQuantity = ProductQuantity;
                #endregion

                #region ProductCode

                Console.Write("Produqtun kodunu daxil edin :");
                product.ProductCode = Console.ReadLine();

                #endregion
                var seleProductCode = _marketableService.Products.Select(m => m.ProductCode).FirstOrDefault();
                if (seleProductCode == product.ProductCode)
                {
                    Console.WriteLine("");
                    Console.WriteLine("{0} - koduna aid məhsul mövcuddur, əlavə edə blməzsiniz!", product.ProductCode);
                }
                else
                {
                    if (product != null)
                    {

                    }


                    _marketableService.AddProduct(product);

                    Console.WriteLine("-------------- Yeni satış əlavə edildi --------------");
                }
            } //+++++

            //  product methodlari 
            static void ShowProductEdit()
            {
                Product product = new Product();
                Console.WriteLine("");
                Console.WriteLine("================Məhsul üzərində düzəliş edin ==================");
                Console.Write("Məhsulun kodunu daxil edin :");
                string code = Console.ReadLine();

                List<Product> productCode = _marketableService.EditProduct(code);

                if (productCode.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Bu koda görə məhsul tapılmadı!");
                }
                else
                {


                    #region Product Name Change 
                    Console.WriteLine("");
                    Console.Write("Məhsulun yeni adını daxil edin:");
                    string ProductName = Console.ReadLine();
                    #endregion

                    #region Product Quantity Change
                    Console.WriteLine("");
                    Console.Write(" Məhsulun yeni sayını daxil edin: ");
                    string productQuantityInput = Console.ReadLine();
                    int productQuantity;
                    while (!int.TryParse(productQuantityInput, out productQuantity))
                    {
                        Console.WriteLine("");
                        Console.Write("Rəqəm daxil etməlisiniz!: ");
                        productQuantityInput = Console.ReadLine();
                    }
                    #endregion

                    #region Product Price 
                    Console.WriteLine("");
                    Console.Write("Məhsulun yeni məbləğini daxil edin:");
                    string productPriceInput = Console.ReadLine();
                    double productPrice;

                    while (!double.TryParse(productPriceInput, out productPrice))
                    {
                        Console.WriteLine("");
                        Console.Write("Rəqəm daxil etməlisiniz!: ");
                        productPriceInput = Console.ReadLine();
                    }
                    #endregion

                    #region Category Change Menu

                    Console.WriteLine("");
                    int selectInt;
                    do
                    {

                        #region product Category Menu 
                        Console.WriteLine("Məhsulun yeni kategoriyasını daxil edin :");
                        Console.WriteLine("0. SonyHeadphone ");
                        Console.WriteLine("1. Tv");
                        Console.WriteLine("2. Computer");
                        Console.WriteLine("3. Phone");
                        #endregion

                        #region Product Category Seletion
                        Console.WriteLine("");
                        Console.Write("Seçiminizi edin:");
                        string select = Console.ReadLine();

                        while (!int.TryParse(select, out selectInt))
                        {
                            Console.WriteLine("");
                            Console.Write("Rəqəm daxil etməlisiniz!: ");
                            select = Console.ReadLine();
                        }
                        #endregion

                        #region Product Category switch
                        switch (selectInt)
                        {
                            case 0:
                                product.ProductCategory = ProductCategoryType.Computer;
                                break;
                            case 1:
                                product.ProductCategory = ProductCategoryType.SonyHeadphone;
                                break;
                            case 2:
                                product.ProductCategory = ProductCategoryType.Tv;
                                break;
                            case 3:
                                product.ProductCategory = ProductCategoryType.Phone;
                                break;
                            default:
                                Console.WriteLine("---------------------------------------------");
                                Console.WriteLine("Siz yalnış seçim etdiniz, 1-4 aralığında seçim etməlisiniz! ");
                                Console.WriteLine("-----------------------------------------------");
                                break;



                        }
                        #endregion

                    } while (selectInt == -1);

                    #endregion

                    foreach (var item in productCode)
                    {
                        item.ProductName = ProductName;
                        item.ProductPrice = productPrice;
                        item.ProductQuantity = productQuantity;
                        item.ProductCategory = (ProductCategoryType)selectInt;
                    }
                }
            } //++++
            static void ShowRemoveProduct()
            { 
                
                Console.WriteLine("");
                Console.WriteLine("-------------- Məhsulu silmək --------------");

                Console.WriteLine("");
                Console.Write("Silmək istədiyiniz məhsulun kodunu daxil edin: ");

                string code = Console.ReadLine();
                _marketableService.RemoveProduct(code);
            }  //+++++++
            static void ShowGetProductByAmountRange()
            {
                Console.WriteLine("===============Qiymət aralığında məhsulların göstərilməsi=================");

                #region Start Amount
                Console.Write("Başlanğıc qiyməti daxil edin:");
                string startAmountInput = Console.ReadLine();
                double startAmount;
                while (!double.TryParse(startAmountInput, out startAmount))
                {
                    Console.Write("Rəqəm daxil etməlisiniz!:");
                    startAmountInput = Console.ReadLine();
                }

                #endregion

                #region End Amount  
                Console.Write("Son qiyməti daxil edin:");
                string endAmountInput = Console.ReadLine();
                double endAmount;
                while (!double.TryParse(endAmountInput, out endAmount))
                {
                    Console.Write("Rəqəm daxil etməlisiniz !:");
                    endAmountInput = Console.ReadLine();
                }
                #endregion

                List<Product> result = _marketableService.GetProductsByAmountRange(startAmount, endAmount);

                if (startAmount > endAmount)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Başlanğıc qiymət bitiş qiymətindən kiçik olmalıdır!");
                }
                else
                {

                    if (result.Count == 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Bu aralıqda məhsul yoxdur!");
                    }
                    else
                    {



                        foreach (var item in result)
                        {
                            if (result != null)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Məhsulun Adı:" + item.ProductName);
                                Console.WriteLine("Məhsulun Qiyməti:" + item.ProductPrice);
                                Console.WriteLine("Məhsulun Kategoruyası:" + item.ProductCategory);
                                Console.WriteLine("Məhsulun Sayı:" + item.ProductQuantity);
                                Console.WriteLine("Məhsulun Kodu:" + item.ProductCode);
                            }
                        }
                    }
                }
            } // ++++++
            static void ShowGetProductsByCategoryName()
            {
                Console.WriteLine("");
                Console.WriteLine("====================kategoriyasına görə məhsulu gösdərmək===================");

                Product product = new Product();
                int selectInt;
                do
                {
                    #region Product Category Name
                    Console.WriteLine("Məhsulun kategoriyasını daxil edin:");
                    Console.WriteLine("0. SonyHeadphone ");
                    Console.WriteLine("1. Tv");
                    Console.WriteLine("2. Computer");
                    Console.WriteLine("3. Phone");
                    #endregion

                    #region Product Category Selection
                    Console.WriteLine("");
                    Console.Write("Seçiminizi edin:");
                    string select = Console.ReadLine();

                    while (!int.TryParse(select, out selectInt))
                    {
                        Console.WriteLine("");
                        Console.Write("Rəqəm daxil etməlisiniz!: ");
                        select = Console.ReadLine();
                    }

                    #endregion
                    #region Product Category Switch 
                    switch (selectInt)
                    {
                        case 0:
                            product.ProductCategory = ProductCategoryType.Tv;
                            break;
                        case 1:
                            product.ProductCategory = ProductCategoryType.Phone;
                            break;
                        case 2:
                            product.ProductCategory = ProductCategoryType.SonyHeadphone;
                            break;
                        case 3:
                            product.ProductCategory = ProductCategoryType.Computer;
                            break;
                        default:
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Siz yalnış seçim etdiniz,0-3 aralığında seçim etməlisiniz");
                            Console.WriteLine("--------------------------------");
                            break;

                            break;
                    }
                    #endregion


                } while (selectInt == -1);

                _marketableService.GetProductsByCategoryName((ProductCategoryType)selectInt);
            } //++++++
            static void ShowGetProductsByProductsName()
            {
                Console.WriteLine("===============Adına görə məhsulun seçilməsi==============");
                Console.WriteLine("");
                Console.Write("Məhsulun adın daxil edin:");
                string productName = Console.ReadLine();
                var count = _marketableService.SaleItems.Select(m => m.SaleCount).FirstOrDefault();
                try
                {
                    var table = new ConsoleTable("No", "Nömrəsi", "Məbləği", "Məhsul sayı", "Tarixi");
                    int i = 1;
                    //var count = _marketableService.SaleItems.Select(m => m.SaleCount).FirstOrDefault();

                    foreach (var item in _marketableService.GetProductsByProductsName(productName))
                    {
                        table.AddRow(i, item.ProductCategory, item.ProductPrice.ToString("#.##"), item.ProductName, item.ProductCode);
                        i++;
                    }
                    table.Write();
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Bu adda məhsul mövcud deyil!");
                }
               

                //table.Write();

            } // +++++=



                // Sale methodlari 
                static void ShowSaleList()
            {
                Console.WriteLine("-------------- Mövcud Satışlar --------------");

                var table = new ConsoleTable("No", "Nömrəsi", "Məbləği", "İtem sayı", "Tarixi");
                int i = 1;
                var count = _marketableService.SaleItems.Select(m => m.SaleCount).FirstOrDefault();

                foreach (var item in _marketableService.Sales)
                {
                    table.AddRow(i, item.SaleNumber, item.SaleAmount.ToString("#.##"), count, item.SaleDate.ToString("dd.MM.yyyy"));
                    i++;
                }

                table.Write();
            }

            static void ShowAddSale()
            {
                Console.WriteLine("");
                Console.WriteLine("================= Yeni satış əlavə edin ================");

                Console.WriteLine("");
                Console.Write("Məhsulun kodunu daxil edin :");
                string productCode = Console.ReadLine();

                Console.WriteLine("");
                Console.Write("Miqdarını daxil edin :");


                string productQuantityInput = Console.ReadLine();
                int productQuantity;
                while (!int.TryParse(productQuantityInput, out productQuantity))
                {
                    Console.WriteLine("");
                    Console.Write("Rəqəm daxil etməlisiniz! :");
                    productQuantityInput = Console.ReadLine();
                    Console.WriteLine("");
                }




                _marketableService.AddSale(productCode, productQuantity);

            }  // exception verdim 
            static void ShowGetSalesByAmountRange()
            {
                Console.WriteLine("===============Qiymət aralığında satışların göstərilmasi==============");

                #region Start Amount
                Console.Write("Başlanğıc qiyməti daxil edin: ");
                string startAmountInput = Console.ReadLine();
                double startAmount;
                while (!double.TryParse(startAmountInput, out startAmount))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz!");
                    startAmountInput = Console.ReadLine();
                }
                #endregion
                #region End Amount
                Console.Write("Son qiyməti daxil edin: ");
                string endAmountInput = Console.ReadLine();
                double endAmount;
                while (!double.TryParse(endAmountInput, out endAmount))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz ");
                    endAmountInput = Console.ReadLine();
                }
                #endregion
                List<Sale> result = _marketableService.GetSalesByAmountRange(startAmount, endAmount);
                if (startAmount > endAmount)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Başlanğıc qiymət bitiş qiymətindən kiçik olmalıdır!");
                }
                else
                {


                    var count = _marketableService.SaleItems.Select(m => m.SaleCount).FirstOrDefault();
                    foreach (var item in result)
                    {
                        if (result != null)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Satışın Nömrəsi: " + item.SaleNumber + "\n" + "Satışın Qiyməti: " + item.SaleAmount.ToString("#.##") + "\n" + "Məhsulun Sayı: " + count + "\n" + "Tarixi:" + item.SaleDate.ToString("dd.MM.yyyy"));
                        }
                    }
                }
            }  // ++++++
            static void ShowGetSalesByDateRange()
            {
                Console.WriteLine("=============Tarix aralığında satışların göstərilməsi================= ");
                #region Start Date 
                Console.Write("Başlanğıc tarixi daxil edin (gün.ay.il):");
                string startDateInput = Console.ReadLine();
                DateTime startDate;
                while (!DateTime.TryParse(startDateInput, out startDate))
                {
                    Console.Write("Tarix daxil etməlisiniz !:");
                    startDateInput = Console.ReadLine();
                }

                #endregion
                #region End Date
                Console.Write("Bitiş tarixi daxil edin: ");
                string endDateInput = Console.ReadLine();
                DateTime endDate;
                while (!DateTime.TryParse(endDateInput, out endDate))
                {
                    Console.Write("Tarix daxil etməlisiniz !:");
                    endDateInput = Console.ReadLine();
                }
                #endregion
                List<Sale> result = _marketableService.GetSalesByDateRange(startDate, endDate);
                if (startDate > endDate)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Başlanğıc tarixi bitiş tarixindən kiçik olmalıdır!");
                }
                else
                {
                    if (result.Count == 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("{0} - {1} tarix aralığında satış yoxdur!", startDate.ToString("dd.MM.yyyy"), endDate.ToString("dd.MM.yyyy"));
                    }
                }

                var count = _marketableService.SaleItems.Select(m => m.SaleCount).FirstOrDefault();

                foreach (var item in result)
                {
                    if (result.Count != 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Satışın  Məbləği:" + item.SaleAmount);
                        Console.WriteLine("Satışın  Vaxtı:" + item.SaleDate.ToString("dd.MM.yyyy"));
                        Console.WriteLine("Satışın  Nömrəsi:" + item.SaleNumber);
                        Console.WriteLine("Satışın  Əşyaları:" + count);
                    }
                }
            }  //+++++++
            static void ShowRemoveSale()
            {
                Sale sale = new Sale();

                Console.WriteLine("");
                Console.WriteLine("===================== Satışı silmək ====================");

                Console.WriteLine("");
                Console.Write("Silmək istədiyiniz satışın nömrəsini daxil edin: ");

                string codeInput = Console.ReadLine();
                int code;

                while (!int.TryParse(codeInput, out code))
                {
                    Console.Write("Rəqəm daxil etməlisiniz!:");
                    codeInput = Console.ReadLine();
                }


                Console.WriteLine("");

                _marketableService.RemoveSale(code);
            }  // +++++++++++
            static void ShowGetSaleByDate()
            {
                Console.WriteLine("");
                Console.WriteLine("================Tarixə görə satışları görmək==============");

                Console.WriteLine("");
                Console.Write("Görmək isdədiyiniz satışın tarixini daxil edin(gün.ay.il):");

                string dateInput = Console.ReadLine();
                DateTime date;
                while (!DateTime.TryParse(dateInput, out date))
                {
                    Console.WriteLine("");
                    Console.Write("Tarix daxil etməlisiniz!:");
                    dateInput = Console.ReadLine();
                }
                List<Sale> sales = _marketableService.GetSaleByDate(date);
                if (sales.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    Console.WriteLine("Bu tarixdə satış yoxdur");
                    Console.WriteLine("==================================");
                }
                else
                {
                    var count = _marketableService.SaleItems.Select(m => m.SaleCount).FirstOrDefault();

                    foreach (var item in sales)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Satışın  Məbləği:" + item.SaleAmount.ToString("#.##"));
                        Console.WriteLine("Satışın  Vaxtı:" + item.SaleDate.ToString("dd.MM.yyyy"));
                        Console.WriteLine("Satışın  Nömrəsi:" + item.SaleNumber);
                        Console.WriteLine("Satışın  Əşyaları:" + count);

                    }
                }
            }  //++++++
            static void ShowGetSaleBySaleNumber()
            {
                Console.WriteLine("");
                Console.WriteLine("==============Satışın nömrəsinə görə satışları görmək=============");

                Console.WriteLine("");
                Console.Write("Görmək istədiyiniz satışın nömrəsini daxil edin:");
                string saleNumberInput = Console.ReadLine();
                int saleNumber;

                while (!int.TryParse(saleNumberInput, out saleNumber))
                {
                    Console.WriteLine("");
                    Console.Write("Rəqəm daxil etməlisiniz! :");
                    saleNumberInput = Console.ReadLine();
                }

                List<Sale> sales = _marketableService.GetSaleBySaleNumber(saleNumber);
                if (sales.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Bu nömrədə satış yoxdur!");
                }
                else
                {
                    var count = _marketableService.SaleItems.Select(m => m.SaleCount).FirstOrDefault();

                    foreach (var item in sales)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Satışın  Məbləği:" + item.SaleAmount.ToString("#.##"));
                        Console.WriteLine("Satışın  Vaxtı:" + item.SaleDate.ToString("dd.MM.yyyy"));
                        Console.WriteLine("Satışın  Nömrəsi:" + item.SaleNumber);
                        Console.WriteLine("Satışın  Əşyaları:" + count);

                    }
                    var list = _marketableService.ShowSaleItem(saleNumber);

                    foreach (var item in list)
                    {
                        Console.WriteLine("Sayi: " + item.SaleCount + "\n" + "İtem Nömrəsi: " + item.SaleItemNumber + "\n" + "Məhsulun Adı: " + item.SaleProduct.ProductName);
                    }
                }
            } //+++++
            static void ShowRemoveProductBySaleItem()
            {
                Console.WriteLine("================= Satışdan məhsulu geri qaytarın =================");
                #region Sale Number
                Console.WriteLine("");
                Console.Write("Satışın nömrəsini daxil edin :");
                string saleNumberInput = Console.ReadLine();
                int saleNumber;
                while (!int.TryParse(saleNumberInput, out saleNumber))
                {
                    Console.WriteLine("");
                    Console.Write("Rəqəm daxil etməlisiniz! :");
                    saleNumberInput = Console.ReadLine();
                }

                #endregion

                #region Quantity
                Console.WriteLine("");
                Console.Write("Satışın miqdarını daxil edin :");
                string productQuantityInput = Console.ReadLine();
                int productQuantity;
                while (!int.TryParse(productQuantityInput, out productQuantity))
                {
                    Console.WriteLine("");
                    Console.Write("Rəqəm daxil etməlisiniz! :");
                    productQuantityInput = Console.ReadLine();
                }
                #endregion

                #region Sale Product Code
                Console.WriteLine("");
                Console.Write("Satışın məhsul kodunu daxil edin:");
                string productCode = Console.ReadLine();
                _marketableService.RemoveProductBySaleItem(saleNumber, productCode, productQuantity);

                #endregion

            } /// ++++++


        }
    }
}
