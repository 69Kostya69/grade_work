using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.Models
{
    public class DishView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[\d,]+(\.\d{1,5})?$", ErrorMessage = "Price must only contain number")]
        public decimal Price { get; set; }

        public string img { get; set; }

        [Required]
        [RegularExpression(@"\d+", ErrorMessage = "Price must only contain number")]
        public int TimeCook { get; set; }

        public TypeOfDish? typeofdish { get; set; }

    }
}
