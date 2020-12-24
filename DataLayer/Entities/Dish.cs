using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public enum TypeOfDish
    {
        Pizza, Sushi, Hot, Salads
    }

    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string img { get; set; }

        public int TimeCook { get; set; }

        public TypeOfDish? typeofdish { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }
       
    }
}
