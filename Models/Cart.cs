using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int SneakerId { get; set; }
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public DateTime DateCreated { get; set; }
        public double Price { get; set; }

        public Sneaker Sneaker { get; set; }
    }
}
