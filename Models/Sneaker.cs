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

        [Display(Name = "Model")]
        [Required]
        public String ModelName { get; set; }

        [Display(Name = "Release Year")]
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public String Description { get; set; }
        public String Material { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0.01, 9999999)]
        public Double Price { get; set; }
        
        public String Image { get; set; }

        [Display(Name = "In stock")]
        [Required]
        public Boolean InStock { get; set; }

        //Child Reference
        [Display(Name = "Brand")]
        public BrandCategory BrandCategory { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
