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
    public async Task AddProductAsync(Product product)
    {
        await _unitOfWork
            .ProductRepository
            .AddProductAsync(product);
    }
    public async Task DeleteProductByGuidAsync(Guid guid)
    {
        await _unitOfWork
            .ProductRepository
            .DeleteProductByGuidAsync(guid);
    }
    public void UpdateProduct(Product product)
    {
        _unitOfWork
            .ProductRepository
            .UpdateProduct(product);
    }
    public async Task<List<Product>> GetProductsPaginatedAsync()
    {
        return await _unitOfWork
            .ProductRepository
            .GetProductsPaginatedAsync();
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _unitOfWork
            .ProductRepository
            .GetProductByIdAsync(id);
    }
    public async Task<Product> GetProductByGuidAsync(Guid guid)
    {
        return await _unitOfWork
            .ProductRepository
            .GetProductByGuidAsync(guid);
    }
    public async Task<List<Product>> GetProductsByNamePaginatedAsync(string name)
    {
        return await _unitOfWork
            .ProductRepository
            .GetProductsByNamePaginated(name);
    }
}