namespace API.Models
{
    public class FoodDrink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}