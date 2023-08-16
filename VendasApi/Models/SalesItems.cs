using System;
using VendasApi.Utils;

namespace VendasApi.Models
{
    public class SalesItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

        public SalesItems()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
