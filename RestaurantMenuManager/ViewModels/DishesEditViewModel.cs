using RestaurantMenuManager.Models;

namespace RestaurantMenuManager.ViewModels
{
    public class DishesEditViewModel
    {
        public Dish Dish { get; set; }

        public DishType[] DishTypesList { get; set; }
    }
}
