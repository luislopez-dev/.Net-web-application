using Application.Abstractions;
using Business.Interfaces;
using Business.Models;

namespace Application.Services;

public class ProductService: IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task AddProductAsync(Product product,CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        await _unitOfWork
            .ProductRepository
            .AddProductAsync(product, cancellationToken);
    }
    public async Task DeleteProductByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await _unitOfWork
            .ProductRepository
            .DeleteProductByGuidAsync(guid, cancellationToken);
    }
    public void UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _unitOfWork
            .ProductRepository
            .UpdateProduct(product, cancellationToken);
    }
    public async Task<List<Product>> GetProductsPaginatedAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _unitOfWork
            .ProductRepository
            .GetProductsPaginatedAsync(cancellationToken);
    }
    public async Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _unitOfWork
            .ProductRepository
            .GetProductByIdAsync(id, cancellationToken);
    }
    public async Task<Product> GetProductByGuidAsync(Guid guid,CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _unitOfWork
            .ProductRepository
            .GetProductByGuidAsync(guid, cancellationToken);
    }
    public async Task<List<Product>> GetProductsByNamePaginatedAsync(string name, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _unitOfWork
            .ProductRepository
            .GetProductsByNamePaginated(name, cancellationToken);
    }
}