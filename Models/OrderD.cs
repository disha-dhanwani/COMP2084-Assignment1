using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class OrderD
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SneakerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        
        //reference
        public Order Order { get; set; }
        public Sneaker Sneaker { get; set; }
    }
}
