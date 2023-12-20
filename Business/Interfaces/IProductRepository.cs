using Business.Models;

namespace Business.Interfaces;

public interface IProductRepository
{
    public Task AddProduct(Product product);
    public void DeleteProduct(Product product);
    public void UpdateProduct(Product product);
    public Task<List<Product>> GetProductsPaginatedAsync();
    public Task<Product> GetProductByIdAsync(int id);
    public Task<List<Product>> GetProductsByNamePaginated(string name);
}