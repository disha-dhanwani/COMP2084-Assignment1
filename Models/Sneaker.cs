using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class Sneaker
    {
        public int SneakerId { get; set; } //Primary Key
        public int BrandCategoryId { get; set; }  //Foreign Key

        [Required]
        public String ModelName { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public String Description { get; set; }
        public String Material { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0.01, 9999999)]
        public Double Price { get; set; }
        [Required]
        public String Image { get; set; }
        [Required]
        public Boolean InStock { get; set; }

        //Child Reference
        public BrandCategory BrandCategory { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
