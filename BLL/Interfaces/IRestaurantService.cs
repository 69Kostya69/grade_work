using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IRestaurantService
    {       
        public IEnumerable<DishDTO> GetDishes();

        public IEnumerable<IngredientDTO> GetIngredients();
        public void AddIngridient(IngredientDTO ingridientDto);
        public void UpdateDish(DishDTO dishtDto);

        public DishDTO GetDish(int id);
        void Dispose();
    }
}
