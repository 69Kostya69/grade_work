using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.BusinessModels;
using BLL.DTO;
using BLL.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace BLL.Services
{
    public  class RestaurantService : IRestaurantService
    {
        IUnitOfWork Database { get; set; }
        public RestaurantService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IEnumerable<DishDTO> GetDishes()
        {           
            var mapper = new MapperConfiguration(c => c.CreateMap<Dish, DishDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Dish>, List<DishDTO>>(Database.Dishes.GetAll());
        }


       

        public void AddIngridient(IngredientDTO ingridientDto)
        {
            Ingredient ingredient = new Ingredient
            {
                Name = ingridientDto.Name,
                DishId= ingridientDto.DishId              
            };
            Database.Ingredients.Create(ingredient);
            Database.Save();
        }

        public void UpdateDish(DishDTO dishtDto)
        {
            var mapper = new MapperConfiguration(c => c.CreateMap<DishDTO, Dish>()).CreateMapper();
            Dish dish = mapper.Map<DishDTO, Dish>(dishtDto);
            Database.Dishes.Update(dish);
            Database.Save();


        }

        public IEnumerable<IngredientDTO> GetIngredients()
        {

            var mapper = new MapperConfiguration(c => c.CreateMap<Ingredient, IngredientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientDTO>>(Database.Ingredients.GetAll());
        }


        public DishDTO GetDish(int idDish)
        {
            var mapper = new MapperConfiguration(c => c.CreateMap<Dish, DishDTO>()).CreateMapper();
            return mapper.Map<Dish, DishDTO>(Database.Dishes.Get(idDish));
        }

        public void Dispose()
        {
            Database.Dispose();
        }



    }
}
