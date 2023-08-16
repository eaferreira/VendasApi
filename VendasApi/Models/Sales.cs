using System;
using System.Collections.Generic;
using VendasApi.Models;
using VendasApi.Utils;

namespace VendasApi.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public double TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public List<SalesItems> Items { get; set; }
        public Employee Employee { get; set; }
        public Utils.PaymentStatus PaymentStatus { get; set; }
    }

}
