using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Entities;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(RestaurantDBContext context)
        {         

            if (!context.Dishes.Any())
            {
                TypeOfDish pizza = TypeOfDish.Pizza;
                TypeOfDish syshi = TypeOfDish.Sushi;
                TypeOfDish salads = TypeOfDish.Salads;

                // create some dishes
                context.Dishes.Add(new Entities.Dish() { Name = "Karbonara", Price = 120, typeofdish = pizza});
                context.Dishes.Add(new Entities.Dish() { Name = "Philadelphia", Price = 150, typeofdish = syshi});
                context.Dishes.Add(new Entities.Dish() { Name = "Neapolitano", Price = 105, typeofdish = pizza});
                context.Dishes.Add(new Entities.Dish() { Name = "California", Price = 125, typeofdish = syshi});
                context.Dishes.Add(new Entities.Dish() { Name = "Caesar", Price = 60, typeofdish = salads});

                context.SaveChanges();
            }

            if (!context.Ingredients.Any())
            {
                // ingredients for Karbonara
                context.Ingredients.Add(new Entities.Ingredient() { Name = "meat", DishId = 1 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "mushrooms", DishId = 1 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "mozzarella cheese", DishId = 1 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "sauce", DishId = 1 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "dough", DishId = 1 });

                // ingredients for Philadelphia
                context.Ingredients.Add(new Entities.Ingredient() { Name = "fish", DishId = 2 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "philadelphia cheese", DishId = 2 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "nori", DishId = 2 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "rice", DishId = 2 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "cucumber", DishId = 2 });

                // ingredients for Neapolitano
                context.Ingredients.Add(new Entities.Ingredient() { Name = "meat", DishId = 3 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "mozzarella cheese", DishId = 3 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "olives", DishId = 3 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "sauce", DishId = 3 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "dough", DishId = 3 });

                // ingredients for California
                context.Ingredients.Add(new Entities.Ingredient() { Name = "fish", DishId = 4 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "philadelphia cheese", DishId = 4 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "cucumber", DishId = 4 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "avocado", DishId = 4 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "nori", DishId = 4 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "rice", DishId = 4 });

                // ingredients for Caesar
                context.Ingredients.Add(new Entities.Ingredient() { Name = "Iceberg lettuce", DishId = 5 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "tomatoes", DishId = 5 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "parmesan cheese", DishId = 5 });
                context.Ingredients.Add(new Entities.Ingredient() { Name = "bread", DishId = 5 });

                context.SaveChanges();
            }

            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "extrimdysik@gmail.com";
            string adminPassword = "5824ec6d";

            string someEmail = "exampleofuser@gmail.com";
            string somePassword = "12345678";

            if (!context.Roles.Any())
            {               

                Role adminRole = new Role { Name = adminRoleName };
                Role userRole = new Role { Name = userRoleName };

                context.Roles.Add(adminRole);
                context.Roles.Add(userRole);

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                User adminUser = new User { Email = adminEmail, Password = adminPassword, RoleId = 1 };
                User someUser = new User { Email = someEmail, Password = somePassword, RoleId = 2 };
                context.Users.Add(adminUser);
                context.Users.Add(someUser);

                context.SaveChanges();
            }
            
        }
    }
}
