using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class Customer
    {
        public int CustomerId { get; set; } //Primary Key
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public String City { get; set; }
        [Required]
        public String Province { get; set; }
        [Required]
        public String PostalCode { get; set; }
        [Required]
        public String Phone { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public int CreditCard { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public List<Order> Orders { get; set; }
    }
}
