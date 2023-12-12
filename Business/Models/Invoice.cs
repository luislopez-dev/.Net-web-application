namespace Business.Models;

public class Invoice
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }
    public string ClientNIT { get; set; }
    public float Discount { get; set; }
    public float Total { get; set; }
    public string PaymetnMethod { get; set; }
}