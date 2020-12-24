using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantApplication.Models;
using BLL.Interfaces;
using BLL.DTO;
using BLL.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace RestaurantApplication.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantService restaurantService;
        public HomeController(IRestaurantService serv)
        {
            restaurantService = serv;
        }

        private string Role()
        {
            string _role;
            try
            {
                _role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            }

            catch
            {
                _role = "user";
            }
            return _role;
        }
        private string Email()
        {
            string _email;
            try
            {
                _email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            catch
            {
                _email = "";
            }
            return _email;
        }

        public IActionResult Index()
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            return View();
        } 

       
        public IActionResult Menu(string tdishes="All")
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            IEnumerable<DishDTO> dishDTOs = restaurantService.GetDishes();
            var mapper = new MapperConfiguration(c => c.CreateMap<DishDTO, DishViewModel>()).CreateMapper();
            var dishes = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(dishDTOs);
            if (tdishes != TypeOfDish.All.ToString())
            {
                
                dishes = dishes.Where(p => p.typeofdish.ToString() == tdishes).ToList();
            }
          
            return View(dishes);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult AddIngridient()
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            IEnumerable<DishDTO> dishesDto = restaurantService.GetDishes();
            var mapper = new MapperConfiguration(c => c.CreateMap<DishDTO, DishViewModel>()).CreateMapper();
            var dishes = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(dishesDto);
            SelectList dishes1 = new SelectList(dishes, "Id", "Name");
            ViewBag.Dishes = dishes1;
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddIngridient(IngredientViewModel ingridient)
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            if (ModelState.IsValid)
            {
                var ingridientDto = new IngredientDTO { Name = ingridient.Name, DishId = ingridient.DishId };
                restaurantService.AddIngridient(ingridientDto);
                return RedirectToAction("Index");
            }
            
           else                         
            return View(ingridient);
        }


        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        /// 

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult ChangePrice()
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            IEnumerable<DishDTO> dishDTOs = restaurantService.GetDishes();
            var mapper = new MapperConfiguration(c => c.CreateMap<DishDTO, DishViewModel>()).CreateMapper();
            var dishes = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(dishDTOs);

            return View(dishes);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]       
        public IActionResult ChangePrice1(int id)
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            var mapper1 = new MapperConfiguration(c => c.CreateMap<DishDTO, DishView>()).CreateMapper();
            var dish = mapper1.Map<DishDTO, DishView>(restaurantService.GetDish(id));

                return View(dish);
        }




        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult ChangePrice1(DishView dish)
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(c => c.CreateMap<DishView, DishDTO>()).CreateMapper();
                var _dishe = mapper.Map<DishView, DishDTO>(dish);
                restaurantService.UpdateDish(_dishe);

                return RedirectToAction("Index");
            }

            else              
                return View(dish);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult ChangeCookingTime()
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            IEnumerable<DishDTO> dishDTOs = restaurantService.GetDishes();
            var mapper = new MapperConfiguration(c => c.CreateMap<DishDTO, DishViewModel>()).CreateMapper();
            var dishes = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(dishDTOs);
           
            return View(dishes);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult ChangeCookingTime1(int id)
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            var mapper1 = new MapperConfiguration(c => c.CreateMap<DishDTO, DishView>()).CreateMapper();
            var dish = mapper1.Map<DishDTO, DishView>(restaurantService.GetDish(id));

            return View(dish);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult ChangeCookingTime1(DishView dish)
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(c => c.CreateMap<DishView, DishDTO>()).CreateMapper();
                var _dish = mapper.Map<DishView, DishDTO>(dish);
                restaurantService.UpdateDish(_dish);
                return RedirectToAction("Index");
            }

            else
                return View(dish);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 


        [Authorize(Roles = "admin, user")]
        public IActionResult Info()
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            ViewBag.role = role;
            return View();
        }




        public IActionResult DetailsDishes(int id=1)
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            var mapper = new MapperConfiguration(c => c.CreateMap<IngredientDTO, IngredientViewModel>()).CreateMapper();
            var ingredients = mapper.Map<IEnumerable<IngredientDTO>, IEnumerable<IngredientViewModel>>(restaurantService.GetIngredients());
            ingredients = ingredients.Where(p => p.DishId == id);


            var mapper1 = new MapperConfiguration(c => c.CreateMap<DishDTO, DishView>()).CreateMapper();
            var dish = mapper1.Map<DishDTO,  DishView > (restaurantService.GetDish(id));
            int dishtime = dish.TimeCook;

            ViewBag.Time = dishtime;
            return View(ingredients);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
       
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
