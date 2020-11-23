using System;
using System.Text;
using ConsoleTables;

namespace MyFirstProject
{
    class Program
    {
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
                        ShowProduct();
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

            static void ShowProduct()
            {
                Console.WriteLine("---------------Məhsullar üzərində əməliyyat aparmaq--------------");
                Console.WriteLine("1. Yeni məhsul əlavə et ");
                Console.WriteLine("2. Məhsul üzərində düzəliş et ");
                Console.WriteLine("3. Məhsulu sil");
                Console.WriteLine("4. Bütün məhsulları göstər ");
                Console.WriteLine("5. Kateqoriyasına görə məhsulları göstər");
                Console.WriteLine("6. Qiymət aralığına görə məhsulları göstər ");
                Console.WriteLine("7. Məhsullar arasında ada görə axtarış et ");
            }
            static void  ShowSale()
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

            }
        }
    }
}
