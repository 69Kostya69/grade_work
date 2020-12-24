using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.Models
{
    public class IngredientViewModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Name must only contain letters")]
        public string Name { get; set; }

        public int DishId { get; set; }
    }
}
