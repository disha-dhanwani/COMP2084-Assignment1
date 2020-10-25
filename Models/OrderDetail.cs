using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class OrderDetail
    {
        /***
         *Creating the Model Table - OrderDetail
         *--This table has the details of order including the sneaker size,
         *quantity, total amount and the dates.
         */
        public int OrderDetailId { get; set; } //Primary Key
        public int CustomerId { get; set; } //Foreign Key
        public int SneakerId { get; set; } //Foreign Key
        public String SneakerSize { get; set; }
        public int Quantity { get; set; }
        public Double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }

        //Child Reference
        public Sneaker Sneaker { get; set; }
        public Customer Customer { get; set; }

        //public List<Order> Orders { get; set; }
    }
}
