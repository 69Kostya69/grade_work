using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class RestaurantCartItem
    {
        public int Id { get; set; }
        public Dish dish { get; set; }
        public int price { get; set; }
        public string RestaurantCartId { get; set; }
    }
}
