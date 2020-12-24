using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.Models
{
    public enum TypeOfDish
    {
      All, Pizza, Sushi, Hot, Salads 
    }

    public class DishViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string img { get; set; }

        public int TimeCook { get; set; }

        public TypeOfDish? typeofdish { get; set; }      

        public int OrderId { get; set; }
    }
}
