using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Order
    {
        public string _id { get; set; }
        public int KindId { get; set; }
        public string Name { get; set; }
        public string Foto  { get; set; }
        public int BestProductId { get; set; }
        public string BestProduct { get; set; }
        public int TotalCountProduct { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
