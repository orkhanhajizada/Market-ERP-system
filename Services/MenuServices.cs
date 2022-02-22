using MarketERP.Data.Entities;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine("Seçdiyiniz  {0} kateqoriya yanlışdır", input);
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
                case Category.Sweets:
                    category = Category.Alchohol;
                    break;
                case Category.Drink:
                    category = Category.Dairy;
                    break;
                case Category.Snack:
                    category = Category.Meat;
                    break;
                
                default:
                    break;
            }

            try
            {
                marketServices.AddProduct(name, double.Parse(price), int.Parse(quantity), code, category);
                Console.WriteLine("Məhsul əlavə edildi");

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Qiymət və say 0`dan  böyük olmalıdır");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Məhsulun adı və kodu boş ola bilməz");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Bu kodda məhsul var artıq");
                Console.WriteLine(e.Message);
            }
        }

        public static void EditProductMenu()
        {
            Console.WriteLine("Məhsulun kodunu daxil edin");
            string oldCode = Console.ReadLine();
            
            var table = new ConsoleTable("No", "Ad", "Qiymət","Say","Cəm Qiymət","Kod","Kategoriya");
            
         
            Product products = marketServices.Products.FirstOrDefault(p => p.Code == oldCode);
            
            table.AddRow(products.No, products.Name, products.Price.ToString("#.00"),products.Quantity,(products.Price*products.Quantity).ToString("#.00"),products.Code,products.ProductCategory);
            
            table.Write();
            Console.WriteLine();
            
            
            Console.WriteLine("Məhsulun adını daxil edin");
            string newName = Console.ReadLine();

            Console.WriteLine("Məhsulun qiymətini daxil edin");
            string newPrice = Console.ReadLine();

            Console.WriteLine("Məhsulun sayınısı daxil edin");
            string newQuantity = Console.ReadLine();

            Console.WriteLine("Məhsulun kodunu daxil edin");
            string newCode = Console.ReadLine();

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
                Console.WriteLine("Seçdiyiniz  {0} kateqoriya yanlışdır", input);
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
                case Category.Sweets:
                    category = Category.Alchohol;
                    break;
                case Category.Drink:
                    category = Category.Dairy;
                    break;
                case Category.Snack:
                    category = Category.Meat;
                    break;
                
                default:
                    break;
            }

            try
            {
                marketServices.EditProduct(newName, double.Parse(newPrice), int.Parse(newQuantity), newCode, category, oldCode);
                Console.WriteLine("Məhsul redakte edildi");

            }
            catch (Exception e)
            {
                Console.WriteLine("Yenidən cəhd edin");
                Console.WriteLine(e.Message);
            }
            
            
        }
        
        public static void DeleteProductMenu()
        {
            Console.WriteLine("Silmək istədiyiniz məhsulun kodunu yazın");
            string code = Console.ReadLine();
            
            
            Product product = marketServices.Products.FirstOrDefault(p => p.Code == code);

            if (product == null)
            {
                Console.WriteLine("Axtardığınız məhsul tapılmadı");
                SubMenuServices.DisplayProductSubMenu();
            }
            
            
            var table = new ConsoleTable("No", "Ad", "Qiymət","Say","Cəm Qiymət","Kod","Kategoriya");
                
            table.AddRow(product.No, product.Name, product.Price.ToString("#.00"),product.Quantity,(product.Price*product.Quantity).ToString("#.00"),product.Code,product.ProductCategory);
            
            table.Write();
            Console.WriteLine();

            Console.WriteLine("Məhsulu silmək istədiyinizdən əminsinizmi? Y/N/Exit");
            string answer = Console.ReadLine()?.ToUpper();

            if (answer == "Y")
            {
                try
                {
                    marketServices.DeleteProduct(product.Code);
                    Console.WriteLine("Məhsul silindi");

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Yazdığınız nömrəyə uyğun kod tapılmadı");
                    Console.WriteLine(e.Message);
                }
            }
            else if (answer == "N")
            {
                DeleteProductMenu();
            }
            else if (answer == "Exit")
            {
                SubMenuServices.DisplayProductSubMenu();
            }
            
            
        }
        
        public static void DisplayProducts()
        {
            var table = new ConsoleTable("No", "Ad", "Qiymət","Say","Cəm Qiymət","Kod","Kategoriya");

            foreach (var products in marketServices.Products)
            {
                table.AddRow(products.No, products.Name, products.Price.ToString("#.00"),products.Quantity,(products.Price*products.Quantity).ToString("#.00"),products.Code,products.ProductCategory);
                
            }

            table.Write();
            Console.WriteLine();
        }
        
        public static void DisplayProductsByCategory()
        {
            
            
            Console.WriteLine("Məhsulun kategoriyasını daxil edin");
            
            Category category;
        
            Console.WriteLine("1. Alkoqollu içkilər");
            Console.WriteLine("2. Süd və süd məhsulları");
            Console.WriteLine("3. Ət və ət məhsulları");
            Console.WriteLine("4. Şirniyyatlar");
            Console.WriteLine("5. İçkilər");
            Console.WriteLine("6. Çərəzlər");

            string input = Console.ReadLine();

            bool success = Enum.TryParse<Category>(input, out category);

            if (!success)
            {
                Console.WriteLine("Seçdiyiniz  {0} kateqoriya yanlışdır", input);
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
                case Category.Sweets:
                    category = Category.Alchohol;
                    break;
                case Category.Drink:
                    category = Category.Dairy;
                    break;
                case Category.Snack:
                    category = Category.Meat;
                    break;
                
                default:
                    break;
            }


            List<Product> productsByCategory = marketServices.Products.FindAll(p => p.ProductCategory == category);
            
            
            var table = new ConsoleTable("No", "Ad", "Qiymət","Say","Cəm Qiymət","Kod","Kategoriya");

            foreach (var products in productsByCategory)
            {
                table.AddRow(products.No, products.Name, products.Price.ToString("#.00"),products.Quantity,(products.Price*products.Quantity).ToString("#.00"),products.Code,products.ProductCategory);
                
            }

            table.Write();
            Console.WriteLine();
        }
        
        
        public static void DisplayProductsByPriceRange()
        {
            
            
            Console.WriteLine("Qiymet aralıöını daxil edin");
            
            Console.WriteLine("Minimum məbləğ");
            double minPrice = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Maksimum məbləğ");
            double maxPrice = double.Parse(Console.ReadLine());
            

            List<Product> productsByPrice = marketServices.Products.FindAll(p => p.Price >= minPrice && p.Price<= maxPrice);

            if (productsByPrice.Count <= 0)
            {
                Console.WriteLine("Axtarışa uyğun nəticə tapılmadı");
                SubMenuServices.DisplayProductSubMenu();
            }
            
            var table = new ConsoleTable("No", "Ad", "Qiymət","Say","Cəm Qiymət","Kod","Kategoriya");

            foreach (var products in productsByPrice)
            {
                table.AddRow(products.No, products.Name, products.Price.ToString("#.00"),products.Quantity,(products.Price*products.Quantity).ToString("#.00"),products.Code,products.ProductCategory);
                
            }

            table.Write();
            Console.WriteLine();
        }
        
        public static void DisplayProductsByName()
        {
            
            
            Console.WriteLine("Məhsulun adını daxil edin");
            string name = Console.ReadLine();
            

            List<Product> productsByName = marketServices.Products.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));

            if (productsByName.Count <= 0)
            {
                Console.WriteLine("Axtarışa uyğun nəticə tapılmadı");
                SubMenuServices.DisplayProductSubMenu();
            }
            
            var table = new ConsoleTable("No", "Ad", "Qiymət","Say","Cəm Qiymət","Kod","Kategoriya");

            foreach (var products in productsByName)
            {
                table.AddRow(products.No, products.Name, products.Price.ToString("#.00"),products.Quantity,(products.Price*products.Quantity).ToString("#.00"),products.Code,products.ProductCategory);
                
            }

            table.Write();
            Console.WriteLine();
        }
        
        #endregion
        
        
        #region Sale
        
        public static void AddSaleItemMenu(Sale sale)
        {
            Console.WriteLine("Məhsulun kodunu daxil edin");
            string code = Console.ReadLine();

            Product product = marketServices.Products.FirstOrDefault(p => p.Code == code);

            Console.WriteLine("Məhsulun sayını daxil edin");
            int quantity = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Məhsulun satış qiymətini daxil edin");
            double price = Double.Parse(Console.ReadLine());

            try
            {
                marketServices.AddSaleItem(product, quantity, price,sale);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Məhsulun sayı və ya qiyməti düzgün deyil");
                throw;
            }
           


        }
            
        public static void AddSaleMenu()
        {
            Sale sale = marketServices.AddSale(DateTime.Now);

            AddSaleItemMenu(sale);

            Console.WriteLine("Məhsul əlavə etmək istəyirsinizmi? Y/N");
            string answer = Console.ReadLine()?.ToUpper();

            if (answer == "Y")
            {
                AddSaleMenu();
            }
            else if (answer == "N")
            {
                try
                {
                    Console.WriteLine("Satış əlavə edildi");
                    SubMenuServices.DisplaySaleSubMenu();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Məhsul sayı azdır");
                    SubMenuServices.DisplaySaleSubMenu();
                }
               
            }
            else
            {
                AddSaleMenu();
            }
            
            
        }
        
        
        public static void DisplaySales()
        {
            var table = new ConsoleTable("No", "Məbləğ","Tarix");
            

            foreach (var sale  in marketServices.SaleItems)
            {
                table.AddRow(sale.SaleNo.No, sale.Price * sale.Quantity,sale.SaleNo.SaleDate);
                
            }

            table.Write();
            Console.WriteLine();
        }

        
        #endregion
        
   
    }
}