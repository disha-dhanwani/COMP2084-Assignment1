using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int OrderDetailId { get; set; }
        public double Total { get; set; }
        
        //Child References
        public Customer Customer { get; set; }
        public OrderDetail OrderDetail { get; set; }

    }
}
