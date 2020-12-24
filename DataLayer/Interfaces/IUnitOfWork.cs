using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Ingredient> Ingredients { get; }
        IRepository<Dish> Dishes { get; }
        
        void Save();
    }
}
