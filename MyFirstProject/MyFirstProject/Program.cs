using System;
using System.Collections.Generic;
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
                    Console.WriteLine("---------------Məhsullar üzərində əməliyyat aparmaq--------------");
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
                            continue;
                        case 6:
                            continue;
                        case 7:
                            continue;                         
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
            static void  ShowSale()
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
                            continue;
                        case 2:
                            continue;
                        case 3:
                            continue;
                        case 4:
                            continue;
                        case 5:
                            continue;
                        case 6:
                            continue;
                        case 7:
                            continue;
                        case 8:
                            continue;
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
            #region Show Methods 
            static void ShowProductList()
            {
                Console.WriteLine("-------------- Mövcud satışlar --------------");

                var table = new ConsoleTable("No", "Kateqoriya", "Məhsul", "Sayı", "Qiyməti","Kodu");
                int i = 1;
                foreach (var item in _marketableService.Products)
                {
                    table.AddRow(i, item.ProductCatagory, item.ProductName, item.ProductQuantity, item.ProductPrice,item.ProductCode);
                    i++;
                }

                table.Write();
            }
            #endregion
            // Add product methodu yaradag 
            static void ShowProductAdd()
            {
                Console.WriteLine("=====================Yeni satış əlavə et=====================");
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
                    Console.WriteLine("Seçiminizi edin:");
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
                            product.ProductCatagory = ProductCategoryType.SonyHeadphone;
                            break;
                        case 2:
                            product.ProductCatagory = ProductCategoryType.Tv;
                            break;
                        case 3:
                            product.ProductCatagory = ProductCategoryType.Computer;
                            break;
                        case 4:
                            product.ProductCatagory = ProductCategoryType.Phone;
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

                Console.WriteLine("Məhsulun adını daxil edin :");
                product.ProductName = Console.ReadLine();
                #endregion

                #region ProductPrice 

                Console.WriteLine("Satışın qiymətini daxil edin :");
               string ProductPriceInput = Console.ReadLine();
                double ProductPrice;
                while (!double.TryParse(ProductPriceInput,out ProductPrice))
                {
                    Console.WriteLine("Ancaq rəqəm daxil etməlisiniz :");
                    ProductPriceInput = Console.ReadLine();
                }
                 product.ProductPrice = ProductPrice;
                #endregion

                #region ProductQuantity 

                Console.WriteLine("Satış sayını daxil edin :");
                string ProductQuantityInput = Console.ReadLine();
                int ProductQuantity;
                while (!int.TryParse(ProductQuantityInput, out ProductQuantity))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz!");
                    ProductQuantityInput = Console.ReadLine();
                }
                product.ProductQuantity=ProductQuantity;
                #endregion

                #region ProductCode

                Console.WriteLine("Produqtun nömrəsini daxil edin :");
                product.ProductCode = Console.ReadLine();

                #endregion
                _marketableService.AddProduct(product);

                Console.WriteLine("-------------- Yeni satış əlavə edildi --------------");
            }
            
           // Edit product methodu yaradag 
           static void ShowProductEdit()
            {
                Product product = new Product();
                Console.WriteLine("");
                Console.WriteLine("================Məhsul üzərində düzəliş edin ==================");
                Console.Write("Məhsulun kodunu daxil edin :");
                string code = Console.ReadLine();

               List<Product> ProductCode = _marketableService.EditProduct(code);
                Console.WriteLine("");
                Console.Write("Məhsulun yeni adını daxil edin:");
                string ProductName = Console.ReadLine();

                Console.WriteLine("");
                Console.Write(" Məhsulun yeni sayını daxil edin: ");
                int ProductQuantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("");
                Console.Write("Məhsulun yeni məbləğini daxil edin:");
                double ProductPrice = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("");
                int selectInt;
                do
                {
                    
                    #region product Category Menu 
                    Console.WriteLine("Kategoriya daxil edin :");
                    Console.WriteLine("0. SonyHeadphone ");
                    Console.WriteLine("1. Tv");
                    Console.WriteLine("2. Computer");
                    Console.WriteLine("3. Phone");
                    #endregion

                    #region Product Category Seletion
                    Console.WriteLine("");
                    Console.WriteLine("Seçiminizi edin:");
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
                            product.ProductCatagory = ProductCategoryType.Computer;
                            break;
                        case 1:
                            product.ProductCatagory = ProductCategoryType.SonyHeadphone;
                            break;
                        case 2:
                            product.ProductCatagory = ProductCategoryType.Tv;
                            break;
                        case 3:
                            product.ProductCatagory = ProductCategoryType.Phone;
                            break;
                        default:
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("Siz yalnış seçim etdiniz, 1-4 aralığında seçim etməlisiniz! ");
                            Console.WriteLine("-----------------------------------------------");
                            break;



                    }
                    #endregion

                } while (selectInt == 0);
                

 
            }

            static void ShowRemoveProduct()
            {
                Console.WriteLine("");
                Console.WriteLine("-------------- Məhsulu silmək --------------");

                Console.WriteLine("");
                Console.Write("Silmək istədiyiniz məhsulun kodunu daxil edin: ");                        

                string code = Console.ReadLine();
                _marketableService.RemoveProduct(code);
            }

        }
    }
}
