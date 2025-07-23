namespace Cinema_task.Models
{
    public class CategoriesAndCinemasVM
    {
        public List<Categories> Categories { get; set; } = null;
        public List<Cinemas> Cinemas { get; set; } = null!;

        public Movies? Movies { get; set; }
    }
}
