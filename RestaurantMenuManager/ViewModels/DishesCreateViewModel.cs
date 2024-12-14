using RestaurantMenuManager.Models;

namespace RestaurantMenuManager.ViewModels
{
    public class DishesCreateViewModel
    {
        public Dish Dish { get; set; }

        public DishType[] DishTypesList { get; set; }
    }
}
