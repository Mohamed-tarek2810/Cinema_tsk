namespace Cinema_task.Models
{
    public class Categories
    {
        public int CategoriesId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Movies> Movies { get; set; } = new List<Movies>();
    }
}
