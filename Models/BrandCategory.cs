/***
 * ASSIGNMENT 2 - COMP2084 [ASP.NET]
 * STUDENT NAME: DISHA DHANWANI
 * STUDENT NUMBER: 200434069
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Models
{
    public class BrandCategory
    {
        /***
         *Creating the Model Table - BrandCategories
         *--This table includes the details of brand categories and the ID
         */
        public int BrandCategoryId { get; set; }  //Primary Key

        [Display(Name = "Brand")]
        [Required]
        public String BrandName { get; set; }

        public List<Sneaker> Sneakers { get; set; }

    }
}
