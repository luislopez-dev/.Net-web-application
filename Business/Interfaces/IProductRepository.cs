using Business.Models;

namespace Business.Interfaces;

public interface IProductRepository
{
    public Task AddProductAsync(Product product);
    public Task DeleteProductByGuidAsync(Guid guid);
    public void UpdateProduct(Product product);
    public Task<List<Product>> GetProductsPaginatedAsync();
    public Task<Product> GetProductByIdAsync(int id);
    public Task<Product> GetProductByGuidAsync(Guid guid);
    public Task<List<Product>> GetProductsByNamePaginated(string name);
}