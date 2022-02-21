using MarketERP.Data.Entities;
using ConsoleTables;
using System;
using MarketERP.Data;

namespace MarketERP.Services
{
    public static class MenuServices
    {
        private static MarketService marketServices = new MarketService();


        #region Products
        
        public static void AddProductMenu()
        {
            Console.WriteLine("Məhsulun adını daxil edin");
            string name = Console.ReadLine();

            Console.WriteLine("Məhsulun qiymətini daxil edin");
            string price = Console.ReadLine();

            Console.WriteLine("Məhsulun sayınısı daxil edin");
            string quantity = Console.ReadLine();

            Console.WriteLine("Məhsulun kodunu daxil edin");
            string code = Console.ReadLine();

            Console.WriteLine("Məhsulun kategoriyasını daxil edin");


            Category category;
        
            Console.WriteLine("1. Alkoqollu içkilər");
            Console.WriteLine("2. Süd və süd məhsulları");
            Console.WriteLine("3. Ət və ət məhsulları");
            Console.WriteLine("4. Şirniyyatlar");
            Console.WriteLine("5. İçkilər");
            Console.WriteLine("6. Çərəzlər");

            string input = Console.ReadLine();

            bool sucess = Enum.TryParse<Category>(input, out category);

            if (!sucess)
            {
                Console.WriteLine("entry {0} is not a valid country", input);
                return;
            }

            switch (category)
            {
                case Category.Alchohol:
                    category = Category.Alchohol;
                    break;
                case Category.Dairy:
                    category = Category.Dairy;
                    break;
                case Category.Meat:
                    category = Category.Meat;
                    break;
            }

            try
            {
                marketServices.AddProduct(name, double.Parse(price), int.Parse(quantity), code, category);
                Console.WriteLine("Məhsul əlavə edildi");

            }
            catch (Exception e)
            {
                Console.WriteLine("Yenidən cəhd edin");
                Console.WriteLine(e.Message);
            }
        }

        public static void DisplayProducts()
        {
            var table = new ConsoleTable("No", "Ad", "Qiymət","Cəm Qiymət","Say","Kod","Kategoriya");

            foreach (var products in marketServices.Products)
            {
                table.AddRow(products.No, products.Name, products.Price.ToString("#.00"),products.Quantity,(products.Price*products.Quantity).ToString("#.00"),products.Code,products.ProductCategory);
                
            }

            table.Write();
            Console.WriteLine();
        }
        
        #endregion
        
    }
}