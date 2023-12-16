namespace Business.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();
}