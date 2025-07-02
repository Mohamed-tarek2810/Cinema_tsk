using System.ComponentModel.DataAnnotations;

namespace Cinema_task.Models
{
    public class ActorMovies
    {
        [Key]
        public int ActorMoviesid { get; set; }
        public int ActorsId { get; set; }
        public Actors Actors { get; set; } = null!;

        public int MoviesId { get; set; }
        public Movies Movies { get; set; } = null!;

    }
}

