
public class Customer:BaseEntity
{

    public ICollection<Order> Orders { get; set; }
    public ICollection<Genre> Genres{ get; set; }
}
