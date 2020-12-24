using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class RestaurantCart
    {
        private readonly RestaurantDBContext db;
        public RestaurantCart(RestaurantDBContext _db)
        {
            this.db = _db;
        }

        public string RestaurantCartId { get; set; }

        public List<RestaurantCartItem> listShopItems { get; set; }

        //public static RestaurantCart GetCart(IServiceProvider services)
        //{
        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        //    var context = services.GetService<RestaurantDBContext>();
        //    string restaurantCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        //    session.SetString("CartId", restaurantCartId);

        //    return new RestaurantCart(context) { RestaurantCartId = restaurantCartId };
        //}

        //public void AddToCart(Dish _dish, int amount)
        //{

        //}

    }
}
