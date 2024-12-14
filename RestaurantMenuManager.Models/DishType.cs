namespace RestaurantMenuManager.Models
{
    public class DishType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public DishType()
        {

        }

        public DishType(int Id, string Type)
        {
            this.Id = Id;
            this.Type = Type;
        }
    }
}
