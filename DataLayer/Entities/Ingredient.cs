using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Ingredient 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DishId { get; set; }

        public virtual Dish Dish { get; set; }

    }
}
