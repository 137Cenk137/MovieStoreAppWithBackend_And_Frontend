public class Actor:BaseEntity
{
    public ICollection<MovieActor> Movies { get; set; }
}

public class MovieActor
{
    public int MovieId { get; set;}
    public Movie Movie { get; set; }

    public Actor Actor { get; set; }
    public int ActorId { get; set; }
}