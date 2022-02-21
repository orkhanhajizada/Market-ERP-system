using MarketERP.Data.Common;

namespace MarketERP.Data.Entities
{
    public class Product: BaseEntity
    {
        private static int _count = 0;

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Code { get; set; }

        public Category Category { get; set; }

        public Product()
        {
            _count++;

            No = _count;
        }
    }
}