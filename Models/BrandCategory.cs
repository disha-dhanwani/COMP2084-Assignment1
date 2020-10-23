using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class BrandCategory
    {
        public int BrandCategoryId { get; set; }  //Primary Key
        [Required]
        public String BrandName { get; set; }

        //public List<Sneaker> Sneakers { get; set; }

    }
}
