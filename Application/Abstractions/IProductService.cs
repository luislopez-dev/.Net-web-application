using Business.Models;

namespace Application.Abstractions;

public interface IProductService
{
    public Task AddProductAsync(Product product, CancellationToken cancellationToken);
    public Task DeleteProductByGuidAsync(Guid guid, CancellationToken cancellationToken);
    public void UpdateProduct(Product product, CancellationToken cancellationToken);
    public Task<List<Product>> GetProductsPaginatedAsync(CancellationToken cancellationToken);
    public Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken);
    public Task<List<Product>> GetProductsByNamePaginatedAsync(string name, CancellationToken cancellationToken);
    public Task<Product> GetProductByGuidAsync(Guid guid, CancellationToken cancellationToken);
}