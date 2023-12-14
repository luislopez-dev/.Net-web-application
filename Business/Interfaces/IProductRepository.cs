using Business.Models;

namespace Business.Interfaces;

public interface IProductRepository
{
    public void AddProduct(Product product);
    public void DeleteProduct(Product product);
    public void UpdateProduct(Product product);
    public Task<List<Product>> GetProductsAsync();
    public Task<Product> GetProductAsync(int id);
}