using System;
using MarketERP.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using MarketERP.Data;

namespace MarketERP.Services
{
    public class MarketService
    {
        public List<Product> Products { get; private set; }
        
        public List<Sale> Sales { get; private set; }
        
        public List<SaleItem> SaleItems { get; private set; }

        public MarketService()
        {
            Products = new List<Product>();
            Sales = new List<Sale>();
            SaleItems = new List<SaleItem>();
        }


        #region Products
        
        public int AddProduct(string name, double price, int quantity, string code, Category category)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("fullname");

            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code");

            if (price <= 0)
                throw new ArgumentOutOfRangeException("price");
            
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("quantity");


            Product product = new();

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            product.Code = code;
            product.ProductCategory = category;
            
            Products.Add(product);

            return product.No;



        }
        
        
        public int EditProduct(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code");
            

            Product product = Products.Find(p => p.Code.ToString() == code.ToString());

            Console.WriteLine("Redaktə etmək istədiyiniz məhsulun adı {0}" , product.Name);
            
            return product.No;


        }
        public int EditProduct(string name, double price, int quantity, string code, Category category)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("fullname");

            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code");

            if (price <= 0)
                throw new ArgumentOutOfRangeException("price");
            
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("quantity");


            Product product = new();

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            product.Code = code;
            product.ProductCategory = category;
            
            Products.Add(product);

            return product.No;



        }
          
        #endregion
    }
}