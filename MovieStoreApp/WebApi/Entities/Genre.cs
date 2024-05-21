public class Genre
{
    public int Id { get; set;}
    public string? GenreName { get; set;}
    public int CustomerId { get; set;}
    public Customer  Customer { get; set; }
}