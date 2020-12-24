using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DishDTO
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
