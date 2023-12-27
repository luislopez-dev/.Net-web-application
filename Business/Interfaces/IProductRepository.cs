/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
 
using Business.Models;

namespace Business.Interfaces;

public interface IProductRepository
{
    public Task AddProductAsync(Product product, CancellationToken cancellationToken);
    public Task DeleteProductByGuidAsync(Guid guid, CancellationToken cancellationToken);
    public void UpdateProduct(Product product, CancellationToken cancellationToken);
    public Task<List<Product>> GetProductsPaginatedAsync(CancellationToken cancellationToken);
    public Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken);
    public Task<Product> GetProductByGuidAsync(Guid guid, CancellationToken cancellationToken);
    public Task<List<Product>> GetProductsByNamePaginated(string name, CancellationToken cancellationToken);
}