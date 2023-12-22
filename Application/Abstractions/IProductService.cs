using Business.Models;

namespace Application.Abstractions;

public interface IProductService
{
    public Task AddProductAsync(Product product);
    public Task DeleteProductByGuidAsync(Guid guid);
    public void UpdateProduct(Product product);
    public Task<List<Product>> GetProductsPaginatedAsync();
    public Task<Product> GetProductByIdAsync(int id);
    public Task<List<Product>> GetProductsByNamePaginated(string name);
    public Task<Product> GetProductByGuidAsync(Guid guid);
}