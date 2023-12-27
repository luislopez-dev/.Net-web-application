/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
 
namespace Business.Models;

public class Product
{
    public int Id { get; set; }
    public Guid Guid { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }

    public List<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();
}