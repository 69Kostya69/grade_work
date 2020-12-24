using System;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Implementations
{
    public class DishRepository : IRepository<Dish>
    {
        private RestaurantDBContext db;

        public DishRepository(RestaurantDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Dish> GetAll()
        {
            return db.Dishes.Include(o=>o.Ingredients);
        }

        public Dish Get(int id)
        {
            return db.Dishes.Find(id);
        }

        public void Create(Dish dish)
        {
            db.Dishes.Add(dish);
        }

        public void Update(Dish dish)
        {
            db.Entry(dish).State = EntityState.Modified;
        }

        public IEnumerable<Dish> Find(Func<Dish, Boolean> predicate)
        {
            return db.Dishes.Include(o=>o.Ingredients).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Dish dish = db.Dishes.Find(id);
            if (dish != null)
                db.Dishes.Remove(dish);
        }
    }
}
