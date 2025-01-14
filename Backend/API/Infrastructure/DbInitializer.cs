using System.Linq;
using API.Models;

namespace API.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Restaurants.Any())
                return;

            var restaurants = new Restaurant[]
            {
                new Restaurant{ Name = "Developer Restaurant" }
            };
            foreach (var restaurant in restaurants)
                context.Restaurants.Add(restaurant);
            context.SaveChanges();

            var foodsDrinks = new FoodDrink[]
            {
                new FoodDrink{ Name = "Banan", Price = 34, RestaurantId = 1 },
                new FoodDrink{ Name = "Eper", Price = 134, RestaurantId = 1 },
                new FoodDrink{ Name = "Alma", Price = 334, RestaurantId = 1 },
                new FoodDrink{ Name = "Korte", Price = 344, RestaurantId = 1 },
                new FoodDrink{ Name = "Kivi", Price = 144, RestaurantId = 1 },
                new FoodDrink{ Name = "Citrom", Price = 14, RestaurantId = 1 },
            };
            foreach (var fooddrink in foodsDrinks)
                context.FoodsDrinks.Add(fooddrink);
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{ RestaurantId = 1, Table = 1, OrderStatusId = OrderStatusId.InProgress, FoodDrinkId = 3 },
                new Order{ RestaurantId = 1, Table = 1, OrderStatusId = OrderStatusId.Served, FoodDrinkId = 4 },
                new Order{ RestaurantId = 1, Table = 2, OrderStatusId = OrderStatusId.InProgress, FoodDrinkId = 1 },
                new Order{ RestaurantId = 1, Table = 2, OrderStatusId = OrderStatusId.Ready, FoodDrinkId = 2 },
                new Order{ RestaurantId = 1, Table = 2, OrderStatusId = OrderStatusId.Served, FoodDrinkId = 6 },
                new Order{ RestaurantId = 1, Table = 3, OrderStatusId = OrderStatusId.Served, FoodDrinkId = 5 },
            };
            foreach (var order in orders)
                context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}