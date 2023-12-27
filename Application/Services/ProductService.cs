using Application.Abstractions;
using Business.Exceptions.Product.Exceptions.DatabaseExceptions;
using Business.Exceptions.Product.Exceptions.ValidationExceptions;
using Business.Interfaces;
using Business.Models;
using Business.Validations;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Services;

public class ProductService: IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ProductValidator _validator;

    public ProductService(IUnitOfWork unitOfWork, ProductValidator validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task AddProductAsync(Product product,CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        try
        {
            ValidationResult result = await _validator
                .ValidateAsync(product, cancellationToken);

            if (!result.IsValid)
            {
                throw new ProductValidationException(result.Errors);
            }
        
            await _unitOfWork
                .ProductRepository
                .AddProductAsync(product, cancellationToken);

            if (!await _unitOfWork.CompleteAsync(cancellationToken))
            {
                throw new CreateProductException();
            }
        }
        catch (Exception e)
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