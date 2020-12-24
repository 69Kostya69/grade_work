using System;
using DataLayer.Interfaces;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DataLayer.Implementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RestaurantDBContext db;

        private IngredientRepository ingredientRepository;
        private DishRepository dishRepository;

        public EFUnitOfWork(RestaurantDBContext context)
        {
            this.db = context;
        }


        public IRepository<Ingredient> Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepository(db);
                return ingredientRepository;
            }
        }

        public IRepository<Dish> Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }      

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
