using MarketERP.Data.Entities;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using MarketERP.Data;

namespace MarketERP.Services{

    public class TableServices
    {
        public  void TableForProductList(List<Product> products)
        {
            var table = new ConsoleTable("No", "Ad", "Qiymət", "Say", "Cəm Qiymət", "Kod", "Kategoriya");

            foreach (var product in products)
            {
                table.AddRow(product.No, product.Name, product.Price.ToString("#.00"), product.Quantity,
                    (product.Price * product.Quantity).ToString("#.00"), product.Code, product.ProductCategory);

            }

            table.Write();
            Console.WriteLine();
        }
        
        public  void TableForSaleList(List<Sale> sales, List<SaleItem> saleItems)
        {
            
            var table = new ConsoleTable("No", "Məbləğ", "Tarix", "Məhsulun sayı");

            foreach (var sale in sales)
            {
                table.AddRow(sale.No, sale.TotalPrice, sale.SaleDate,saleItems.Where(s => s.Sale.No == sale.No).Sum(s => s.Quantity));
            }
            

            table.Write();
            Console.WriteLine();
            
        }
        
    }
}