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
                       
                        break;
                    case 2:
                        
                        break;
                    
                    default:
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("==========Siz yanlış seçim etdiniz=========== ");
                        Console.WriteLine("----------------------------------");
                        break;
                }
                
                #endregion
                

            } while (selectInt != 0);
            
        }
    }
}
