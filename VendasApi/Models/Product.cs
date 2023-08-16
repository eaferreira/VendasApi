using System;
using System.Collections.Concurrent;
using VendasApi.Models;

namespace VendasApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }

        public Product()
        {
            CreatedDate = DateTime.Now;
        }
    }

}
