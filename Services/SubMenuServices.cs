using System;
using MarketERP.Services;
using MarketERP.Data.Entities;

namespace MarketERP.Services
{
    public static class SubMenuServices
    {
        public static void DisplayProductSubMenu()
        {
            int selection = 0;

            do
            {
                Console.WriteLine("1. Yeni məhsul əlavə et");
                Console.WriteLine("2. Məhsulu redaktə et");
                Console.WriteLine("3. Məhsulu sil");
                Console.WriteLine("4. Bütün məhsullar");
                Console.WriteLine("5. Kateqoriyaya görə məhsullar");
                Console.WriteLine("6. Qiymət aralığına görə məhsullar");
                Console.WriteLine("7. Ada görə axtarış");
                Console.WriteLine("8. Ana səhifəyə qayıt");
                
                Console.WriteLine("Zəhmət olmasa menudan seçim edin");
                
                string selectionStr = Console.ReadLine();
                selection = int.Parse(selectionStr);


                switch (selection)
                {
                    case 1:
                        MenuServices.AddProductMenu();
                        break;
                    case 2:
                        Console.WriteLine("product 2");
                        break;
                    case 3:
                        Console.WriteLine("product 3");
                        break;
                    case 4:
                        MenuServices.DisplayProducts();
                        break;
                    case 8:
                        Program.MainMenu();
                        break;
                    default:
                        break;
                }
                
            } while (selection != 8);
        }

        public static void DisplaySaleSubMenu()
        {
            int selection = 0;

            do
            {
                Console.WriteLine("1. Yeni satış əlavə et");
                Console.WriteLine("2. Staışın anbara qayıtması");
                Console.WriteLine("3. Satışın silinməsi");
                Console.WriteLine("4. Satışların siyahısı");
                Console.WriteLine("5. Tarix aralığına görə satışlar");
                Console.WriteLine("6. Satış qiyməti aralığına görə satışlar");
                Console.WriteLine("7. Verilmiş tarixdəki satışlar");
                Console.WriteLine("8. Satış nömrəsinə görə axtarış");
                Console.WriteLine("9. Ana səhifəyə qayıt");
                
                Console.WriteLine("Please select your option");
                
                string selectionStr = Console.ReadLine();
                selection = int.Parse(selectionStr);


                switch (selection)
                {
                    case 1:
                        Console.WriteLine("sale 1");
                        break;
                    case 2:
                        Console.WriteLine("sale 2");
                        break;
                    case 3:
                        Console.WriteLine("sale 3");
                        break;
                    case 9:
                        Program.MainMenu();
                        break;
                    default:
                        break;
                }
                
            }while (selection != 9);
        }
        
    }
}