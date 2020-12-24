using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.Models
{
    public class DishPriceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\d{2}", ErrorMessage = "Price must only contain number")]
        public decimal Price { get; set; }
    }
}
