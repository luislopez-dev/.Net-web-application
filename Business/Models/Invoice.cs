namespace Business.Models;

public class Invoice
{
    public int Id { get; set; }
    public Guid Guid { get; set; } = Guid.NewGuid();
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }
    public string ClientNit { get; set; }
    public float Discount { get; set; } = 2;
    public float Total { get; set; } = 100;
    public string PaymentMethod { get; set; }
    
    public List<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();
}