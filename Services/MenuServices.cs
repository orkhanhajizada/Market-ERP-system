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

        private static TableServices tableServices = new TableServices();

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

            List<Product> products = marketServices.Products.Where(p => p.Code == oldCode).ToList();

            tableServices.TableForProductList(products);

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
                marketServices.EditProduct(newName, double.Parse(newPrice), int.Parse(newQuantity), newCode, category,
                    oldCode);
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

            List<Product> products = marketServices.Products.Where(p => p.Code == code).ToList();

            if (products.Count == 0)
            {
                Console.WriteLine("Axtardığınız məhsul tapılmadı");
                SubMenuServices.DisplayProductSubMenu();
            }
            
            tableServices.TableForProductList(products);

            Console.WriteLine("Məhsulu silmək istədiyinizdən əminsinizmi? Y/N/Exit");
            string answer = Console.ReadLine()?.ToUpper();

            if (answer == "Y")
            {
                try
                {
                    marketServices.DeleteProduct(products.FirstOrDefault(p=>p.Code == code).Code);
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
            tableServices.TableForProductList(marketServices.Products);
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

            List<Product> products = marketServices.Products.FindAll(p => p.ProductCategory == category);

            tableServices.TableForProductList(products);
            
        }

        public static void DisplayProductsByPriceRange()
        {
            Console.WriteLine("Qiymet aralığını daxil edin");

            Console.WriteLine("Minimum məbləğ");
            double minPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Maksimum məbləğ");
            double maxPrice = double.Parse(Console.ReadLine());
            
            if (minPrice > maxPrice)
            {
                Console.WriteLine("Məbləğ aralığı düzgün deyil");
            }

            List<Product> products =
                marketServices.Products.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice);

            if (products.Count <= 0)
            {
                Console.WriteLine("Axtarışa uyğun nəticə tapılmadı");
                SubMenuServices.DisplayProductSubMenu();
            }
            
            tableServices.TableForProductList(products);
            
        }

        public static void DisplayProductsByName()
        {
            Console.WriteLine("Məhsulun adını daxil edin");
            string name = Console.ReadLine();

            List<Product> products =
                marketServices.Products.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));

            if (products.Count <= 0)
            {
                Console.WriteLine("Axtarışa uyğun nəticə tapılmadı");
                SubMenuServices.DisplayProductSubMenu();
            }
            
            tableServices.TableForProductList(products);

        }

        public static void AddProdtest()
        {
            marketServices.AddProd();
        }

        #endregion


        #region Sale

        public static void AddSaleItemMenu(Sale sale)
        {
            Console.WriteLine("Məhsulun kodunu daxil edin");
            string code = Console.ReadLine();

            Product product = marketServices.Products.FirstOrDefault(p => p.Code == code);

            if (product == null)
            {
                Console.WriteLine("Məhsulun kodu düzgün deyil");
                AddSaleItemMenu(sale);
            }

            Console.WriteLine("Məhsulun sayını daxil edin");
            int quantity = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Məhsulun satış qiymətini daxil edin");
            double price = Double.Parse(Console.ReadLine());

            try
            {
                marketServices.AddSaleItem(product, quantity, price, sale);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Məhsulun sayı və ya qiyməti düzgün deyil");
                throw;
            }
        }

        public static string AddOtherSaleitem( Sale sale)
        {
            
            Console.WriteLine("Məhsul əlavə etmək istəyirsinizmi? Y/N");
            string answer = Console.ReadLine()?.ToUpper();

            if (answer == "Y")
            {
                AddSaleItemMenu(sale);
                AddOtherSaleitem(sale);
            }
            else if (answer == "N")
            {
                return answer;
            }
            else
            {
                Console.WriteLine("Seçiminiz düzgün deyil");
                AddOtherSaleitem(sale);
            }

            return answer;
        }
        
        public static void AddSaleMenu()
        {
            Sale sale = marketServices.AddSale(DateTime.Now);

            AddSaleItemMenu(sale);
            var answer = AddOtherSaleitem(sale);
            
            Console.WriteLine("Satış əlavə edildi");

            SubMenuServices.DisplaySaleSubMenu();
            
        }

        public static void DeleteSingleSaleItemMenu()
        {
            tableServices.TableForSaleList(marketServices.Sales , marketServices.SaleItems);

            Console.WriteLine("Satışın nömrəsini daxil edin");
            string no = Console.ReadLine();
            
            tableServices.TableForProductList(marketServices.Products);

            Console.WriteLine("Məhsulun nömrəsini daxil edin");
            string saleItemNo = Console.ReadLine();
            
            try
            {
                marketServices.DeleteSingleSaleItem(int.Parse(no),saleItemNo);
                Console.WriteLine("Məhsul uğurla satışdan silindi");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Daxil etdiyiniz nömrə üzrə satış tapılmadı");
                
            }
        }
        
        public static void DeleteSaleMenu()
        {
            tableServices.TableForSaleList(marketServices.Sales,marketServices.SaleItems);

            Console.WriteLine("Satışın nömrəsini daxil edin");
            string no = Console.ReadLine();
            
            try
            {
                marketServices.DeleteSale(int.Parse(no));
                Console.WriteLine("Satış uğurla silindi");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Daxil etdiyiniz nömrə üzrə satış tapılmadı");
                
            }
            
        }
        
        public static void DisplaySales()
        {
            tableServices.TableForSaleList(marketServices.Sales,marketServices.SaleItems);
        }
        
        public static void DisplaySalesByDateRange()
        {

            Console.WriteLine("Tarix aralığını daxil edin");

            Console.WriteLine("Başlanğıc tarixi (MM.dd.yyyy formatı ilə)");
            DateTime minDate = DateTime.Parse(DateTime.Parse(Console.ReadLine()).ToString("MM.dd.yyyy"));

            Console.WriteLine("Bitmə tarixi (MM.dd.yyyy formatı ilə)");
            DateTime maxDate = DateTime.Parse(DateTime.Parse(Console.ReadLine()).ToString("MM.dd.yyyy"));

            if (minDate > maxDate)
            {
                Console.WriteLine("Tarix aralığı düzgün deyil");
            }
            
            var sales =
                marketServices.Sales.Where(s => s.SaleDate >= minDate && s.SaleDate <= maxDate).ToList();

            if (sales.Count <= 0)
            {
                Console.WriteLine("Axtarışa uyğun nəticə tapılmadı");
                SubMenuServices.DisplaySaleSubMenu();
            }

            tableServices.TableForSaleList(sales,marketServices.SaleItems);
            
        }
        
        public static void DisplaySalesByPriceRange()
        {
            Console.WriteLine("Qiymet aralığını daxil edin");

            Console.WriteLine("Minimum məbləğ");
            double minPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Maksimum məbləğ");
            double maxPrice = double.Parse(Console.ReadLine());

            if (minPrice > maxPrice)
            {
                Console.WriteLine("Məbləğ aralığı düzgün deyil");
            }

            var sales =
                marketServices.Sales.Where(s => s.TotalPrice >= minPrice && s.TotalPrice <= maxPrice).ToList();

            if (sales.Count <= 0)
            {
                Console.WriteLine("Axtarışa uyğun nəticə tapılmadı");
                SubMenuServices.DisplaySaleSubMenu();
            }
            tableServices.TableForSaleList(sales,marketServices.SaleItems);
            
        }

        public static void DisplaySalesByDate()
        {

            Console.WriteLine("Tarixi  daxil edin (MM.dd.yyyy formatı ilə)");
            
            DateTime date = DateTime.Parse(DateTime.Parse(Console.ReadLine()).ToString("MM.dd.yyyy"));

            var sales =
                marketServices.Sales.Where(s => s.SaleDate.Date == date).ToList();

            if (sales.Count <= 0)
            {
                Console.WriteLine("Axtarışa uyğun nəticə tapılmadı");
                SubMenuServices.DisplaySaleSubMenu();
            }
            tableServices.TableForSaleList(sales, marketServices.SaleItems);
            
        }
        
        public static void DisplaySaleById()
        {

            Console.WriteLine("Satış nömrəsini daxil edin");
            
             int no = Int32.Parse(Console.ReadLine());

             var sales =
                 marketServices.Sales.Where(s => s.No == no).ToList();


             if (sales.Count == 0)
             {
                 Console.WriteLine("Axtarışa uyğun nəticə tapılmadı");
                 SubMenuServices.DisplaySaleSubMenu();
             }

             tableServices.TableForSaleList(sales,marketServices.SaleItems);
             
        }

        #endregion

}
}