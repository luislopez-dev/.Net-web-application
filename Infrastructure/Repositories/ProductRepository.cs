using Business.Exceptions.Product.Exceptions.DatabaseExceptions;
using Business.Interfaces;
using Business.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class ProductRepository: IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }
    public async Task AddProductAsync(Product product, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            await _context.AddAsync(product, cancellationToken);
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
            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Guid == guid, cancellationToken);
            _context.Remove(product);
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
            _context.Entry(product).State = EntityState.Modified;
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
            var products = from n in _context.Products select n;
        
            return await products.ToListAsync(cancellationToken);
        }
        catch (GetProductsException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            return await _context
                .Products
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }
        catch (GetProductException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Product> GetProductByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        try
        {
            return await _context
                .Products
                .FirstOrDefaultAsync(m => m.Guid == guid, cancellationToken);
        }
        catch (GetProductsException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Product>> GetProductsByNamePaginated(string name, CancellationToken cancellationToken)
    {
        try
        {
            return await _context
                .Products
                .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
                .OrderBy(p => p.Id)
                .ToListAsync(cancellationToken);
        }
        catch (GetProductsException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}