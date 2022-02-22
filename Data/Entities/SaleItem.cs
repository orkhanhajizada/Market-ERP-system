using MarketERP.Data.Common;

namespace MarketERP.Data.Entities
{
    public class SaleItem : BaseEntity

    {
        private static int _count = 0;
        
        public Product ProductCode { get; set; }
        
        public  Sale SaleNo { get; set; }
        
        public int Quantity { get; set; }
        
        public double Price { get; set; }
        
        


        public SaleItem()
        {
            _count++;
            
            No = _count;
        }

    }
}