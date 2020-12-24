using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Implementations
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private RestaurantDBContext db;

        public IngredientRepository(RestaurantDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return db.Ingredients;
        }

        public Ingredient Get(int id)
        {
            return db.Ingredients.Find(id);
        }

        public void Create(Ingredient ingredient)
        {
            db.Ingredients.Add(ingredient);
        }

        public void Update(Ingredient ingredient)
        {
            db.Entry(ingredient).State = EntityState.Modified;
        }

        public IEnumerable<Ingredient> Find(Func<Ingredient, Boolean> predicate)
        {
            return db.Ingredients.Where(predicate).ToList();
        }

     
        public void Delete(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient != null)
                db.Ingredients.Remove(ingredient);
        }
    }
}
