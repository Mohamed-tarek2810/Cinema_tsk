namespace Cinema_task.Models
{
    public class Movies
    {
        public int MoviesId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieStatus MovieStatus { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; } = null!;
        public int CategoryId { get; set; }
        public Categories Category { get; set; } = null!;
        public ICollection<ActorMovies> ActorMovies { get; set; } = new List<ActorMovies>();
    }

    public enum MovieStatus
    {
        Coming,
        Available,
        Expire
    }

}