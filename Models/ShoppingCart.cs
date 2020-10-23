using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }  //Primary Key
        public int SneakerId { get; set; }  //Foreign Key
        public int CustomerId { get; set; }
        public int DateAdded { get; set; }
        public int DateModified { get; set; }
        public int Quantity { get; set; }
        //Child Reference
        public Sneaker Sneaker { get; set; }
        public Customer Customer { get; set; }


    }
}
