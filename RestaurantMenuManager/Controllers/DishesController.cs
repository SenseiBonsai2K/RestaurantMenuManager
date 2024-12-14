using Microsoft.AspNetCore.Mvc;
using RestaurantMenuManager.Models;
using RestaurantMenuManager.ViewModels;

namespace RestaurantMenuManager.Controllers
{
    public class DishesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            PopulateDishes();
            DishesIndexViewModel vm = new DishesIndexViewModel();
            vm.AllDishes = Static.Dishes.ToArray();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            DishesCreateViewModel vm = new DishesCreateViewModel();
            vm.DishTypesList = Static.DishTypes.ToArray();
            vm.Dish = new Dish();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DishesCreateViewModel vm)
        {
            if (Static.Dishes.Any(d => d.Id == vm.Dish.Id))
            {
                ModelState.AddModelError("Dish.Id", "The Id is already in use.");
            }

            if (vm.Dish.Id < 0)
            {
                ModelState.AddModelError("Dish.Id", "The Id HAVE to be a positive number and not 0.");
            }

            if(vm.Dish.Price < 0)
            {
                ModelState.AddModelError("Dish.Price", "The Price HAVE to be a positive number and not 0.");
            }

            if (ModelState.IsValid)
            {
                Static.Dishes.Add(vm.Dish);
                return Redirect("/Dishes/Index");
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            DishesEditViewModel vm = new DishesEditViewModel();
            vm.Dish = Static.Dishes.Where(d => d.Id == Id).First();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Dish dish)
        {
            Dish staticD = Static.Dishes.Where(d => d.Id == dish.Id).First();

            staticD.Type = dish.Type;

            return Redirect("/Dishes/Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dish = Static.Dishes.FirstOrDefault(d => d.Id == id);
            if (dish != null)
            {
                Static.Dishes.Remove(dish);
            }
            return Redirect("/Dishes/Index");
        }

        public void PopulateDishes()
        {
            if (Static.Dishes == null)
            {
                Static.Dishes = new List<Dish>();

                Static.Dishes.Add(new Dish(1, "Tagliere Affettati", 8.40 , "Apetizer"));
                Static.Dishes.Add(new Dish(2, "Carbonara", 12.50, "Main Course"));
                Static.Dishes.Add(new Dish(3, "Tiramisu", 5.10, "Dessert"));
            };
        }
    }
}
