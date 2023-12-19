namespace Business.Models;

public class InvoiceProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}