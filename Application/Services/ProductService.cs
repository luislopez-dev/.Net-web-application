using Application.Abstractions;
using Business.Exceptions.Product.Exceptions.DatabaseExceptions;
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

        try
        {
            await _unitOfWork
                .ProductRepository
                .AddProductAsync(product, cancellationToken);
        }
        catch (CreateProductException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task DeleteProductByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        try
        {
            await _unitOfWork
                .ProductRepository
                .DeleteProductByGuidAsync(guid, cancellationToken);
        }
        catch (DeleteProductException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public void UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            _unitOfWork
                .ProductRepository
                .UpdateProduct(product, cancellationToken);
        }
        catch (UpdateProductException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<List<Product>> GetProductsPaginatedAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await _unitOfWork
                .ProductRepository
                .GetProductsPaginatedAsync(cancellationToken);
        }
        catch (GetProductsException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await _unitOfWork
                .ProductRepository
                .GetProductByIdAsync(id, cancellationToken);
        }
        catch (GetProductException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<Product> GetProductByGuidAsync(Guid guid,CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await _unitOfWork
                .ProductRepository
                .GetProductByGuidAsync(guid, cancellationToken);
        }
        catch (GetProductException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<List<Product>> GetProductsByNamePaginatedAsync(string name, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await _unitOfWork
                .ProductRepository
                .GetProductsByNamePaginated(name, cancellationToken);
        }
        catch (GetProductsException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}