using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ModelsDto
{
    public class OrderDto
    {
        public string method { get; set; }
        public Order order { get; set; }
    }
}
