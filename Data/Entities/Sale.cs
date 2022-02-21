using System;
using MarketERP.Data.Common;

namespace MarketERP.Data.Entities
{
    public class Sale : BaseEntity
    {
        private static int _count = 0;

        public double Price { get; set; }
        
        public SaleItem Items { get; set; }
        
        public DateTime SaleDate { get; set; }

        public Sale()
        {
            _count++;

            No = _count;
        }
    }
}