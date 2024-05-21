public class Order
{
    public int OrderId { get; set;}
    public double TotalPrice { get; set; }
    public ICollection<Movie> Movies { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
}