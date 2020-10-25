using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class ShoppingCart
    {
        /***
         *Creating the Model Table - ShoppingCart
         *--This table includes the details of items in Shopping cart.
         */
        public int ShoppingCartId { get; set; }  //Primary Key
        public int SneakerId { get; set; }  //Foreign Key
        public int CustomerId { get; set; }
        public int DateAdded { get; set; }
        public int DateModified { get; set; }
        public int Quantity { get; set; }
        public Double Price { get; set; }
        public Double Total { get; set; }
        [Display(Name = "Size")]
        public String SneakerSize { get; set; }

        //Child Reference
        public Sneaker Sneaker { get; set; }
        public Customer Customer { get; set; }


    }
}
