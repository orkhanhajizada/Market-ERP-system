using System;
using System.Collections;
using System.Collections.Generic;
using MarketERP.Data.Common;

namespace MarketERP.Data.Entities
{
    public class Sale : BaseEntity
    {
        private static int _count = 0;
        public double TotalPrice { get; set; }
        public DateTime SaleDate { get; set; }

        //public ICollection<SaleItem> SaleItems{ get; set; }

        public Sale()
        {
            _count++;

            No = _count;
        }
    }
}