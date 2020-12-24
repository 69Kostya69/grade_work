using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.Models
{
    public class DishIngredientsViewModel
    {
        public IEnumerable<DishViewModel> D{get; set;}
        public IEnumerable<IngredientViewModel> I { get; set; }
    }
}
