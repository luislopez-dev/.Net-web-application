using Business.Models;

namespace Application.Abstractions;

public interface IProductService
{
    public void AddProduct(Product product);
    public void DeleteProduct(Product product);
    public void UpdateInvoice(Product product);
    public Task<List<Product>> GetProductsAsync();
    public Task<Product> GetProductAsync(int id);
}