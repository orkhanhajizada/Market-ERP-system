using System;
using MarketERP.Data.Entities;
using System.Collections.Generic;
using System.Linq;
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
            
            Product products = Products.FirstOrDefault(p => p.Code == code);

            if (products != null)
                throw new ArgumentException();

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

        }  //Add product method

        public void AddProd() //Add default products for test 
        {
            Product product = new Product();

            product.Name = "test1";
            product.Price = 5;
            product.Quantity = 20;
            product.Code = "123";
            product.ProductCategory = Category.Dairy;
            
            Products.Add(product);
            
            Product product1 = new Product();

            product1.Name = "test2";
            product1.Price = 3;
            product1.Quantity = 30;
            product1.Code = "321";
            product1.ProductCategory = Category.Dairy;
            
            Products.Add(product1);
        } 
        
        public int EditProduct(string newName, double newPrice, int newQuantity, string newCode, Category category,string oldCode)
        {
            if (string.IsNullOrEmpty(newName))
                throw new ArgumentNullException("fullname");

            if (string.IsNullOrEmpty(newCode))
                throw new ArgumentNullException("code");

            if (newPrice <= 0)
                throw new ArgumentOutOfRangeException("price");
            
            if (newQuantity <= 0)
                throw new ArgumentOutOfRangeException("quantity");


            Product product = Products.FirstOrDefault(p => p.Code == oldCode);

            product.Name = newName;
            product.Price = newPrice;
            product.Quantity = newQuantity;
            product.Code = newCode;
            product.ProductCategory = category;

            return product.No;



        } //Edit selected product method
        
        public void DeleteProduct(string code)
        {
            
            Product product = Products.FirstOrDefault(p => p.Code == code);

            if (product == null)
                throw new ArgumentNullException();

            Products.Remove(product);
        } //Delete selected product method
          
        #endregion


        #region Sale

        public Sale AddSale(DateTime date)
        {
            Sale sale = new Sale()
            {
                SaleDate = date,
                TotalPrice = 0
            };
            Sales.Add(sale);
            
            return sale;
        } //Add sale method
        
        public int AddSaleItem(Product product,int quantity, double price,Sale sale)
        {
            
            if (price <= 0)
                throw new ArgumentOutOfRangeException("price");
            
            if (quantity <= 0 && quantity > product.Quantity)
                throw new ArgumentOutOfRangeException("quantity");

            SaleItem saleItem = new();

            saleItem.ProductCode = product;
            saleItem.Quantity = quantity;
            saleItem.Price = price;
            saleItem.Sale = sale;
            sale.TotalPrice +=(price * quantity) ;
            product.Quantity -= quantity;

            SaleItems.Add(saleItem);
            

            return product.No;
        } //Add sale item to sale method

        public void DeleteSingleSaleItem(int no , string saleItemNo)
        {
            var sale = Sales.FirstOrDefault(s => s.No == no);
            
            if (sale == null)
                throw new ArgumentNullException();
            
            var saleItems = SaleItems.FindAll(s =>s.Sale.No == sale.No && s.ProductCode.Code == saleItemNo).ToList();
            
            if (saleItems == null)
                throw new ArgumentNullException();

            foreach (var salesItem in saleItems)
            {
                var product = Products.FirstOrDefault(p => p.Code == salesItem.ProductCode.Code);

                product.Quantity += salesItem.Quantity;

                sale.TotalPrice -= salesItem.Price * salesItem.Quantity;
                
                SaleItems.Remove(salesItem);

            }

            
        } //Delete selected sale item from sale  method
        
        public void DeleteSale(int no)
        {
            
            int sale = Sales.FindIndex(s => s.No == no);
            
            var saleItems = SaleItems.Where(s => s.Sale.No == no).ToList();

            foreach (var salesItem in saleItems)
            {
                var product = Products.FirstOrDefault(p => p.Code == salesItem.ProductCode.Code);

                product.Quantity += salesItem.Quantity;

            }

            if (sale == -1)
                throw new ArgumentNullException();

            Sales.RemoveAt(sale);
        } //Delete selected sale method
        
        
        #endregion
    }
}