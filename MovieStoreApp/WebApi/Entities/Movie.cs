public class Movie
{

    public int Id { get; set;}
    public string? Name { get; set; }
    public float Price { get; set; }
    public DateTime PublishDate { get; set; }
    public string? Description { get; set; }

    public Director Director { get; set; }

    public Order Order{ get; set; }
    public int? OrderId { get; set; }
    
    public Genre Genre { get; set; }
    public int? GenreId { get; set; }


    public ICollection<MovieActor>? Actors { get; set; }

    




}