using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class InvoiceProduct
{
    public int Id { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}