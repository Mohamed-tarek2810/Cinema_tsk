namespace Cinema_task.Models
{
    public class Actors
    {
        public int ActorsId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string News { get; set; } = string.Empty;

        public ICollection<ActorMovies> ActorsMovies { get; set; } = new List<ActorMovies>();
    }
}
