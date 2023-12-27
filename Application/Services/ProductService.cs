using Application.Abstractions;
using Business.Exceptions.Product.Exceptions;
using Business.Interfaces;
using Business.Models;
using Business.Validations;
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
            // Start validations
            ValidationResult validation = await _validator
                .ValidateAsync(product, cancellationToken);

            if (!validation.IsValid)
                throw new ProductValidationException(validation.Errors);
            
            // Start DB operations
            await _unitOfWork
                .ProductRepository
                .AddProductAsync(product, cancellationToken);

            if (!await _unitOfWork.CompleteAsync(cancellationToken))
                throw new CreateProductException();
        }
        catch (CreateProductException e)
        {
            // Handling CreateProductException
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
            
            if (!await _unitOfWork.CompleteAsync(cancellationToken))
                throw new DeleteProductException();
        }
        catch (DeleteProductException e)
        {
            // Handle DeleteProductException
        }
    }
    public async Task UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            ValidationResult validation = await _validator
                .ValidateAsync(product, cancellationToken);

            if (!validation.IsValid)
                throw new ProductValidationException(validation.Errors);

            _unitOfWork
                .ProductRepository
                .UpdateProduct(product, cancellationToken);

            if (!await _unitOfWork.CompleteAsync(cancellationToken))
                throw new UpdateProductException();
        }
        catch (UpdateProductException e)
        {
            // Handling UpdateProductException
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
            throw;
        }
    }
}