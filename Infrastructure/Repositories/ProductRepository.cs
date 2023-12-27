using System.Data.Common;
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
        catch (DbUpdateException e)
        {
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
        catch (DbUpdateException e)
        {
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
        catch (DbUpdateException e)
        {
            // DbUpdateException handling
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
        catch (DbException e)
        {
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
        catch (DbException e)
        {
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
        catch (DbException e)
        {
            throw;
        }
    }

    public async Task<List<Product>> GetProductsByNamePaginated(string name, CancellationToken cancellationToken)
    {
        try
        {
            return await _context
                .Products
                .Where(p => EF.Functions
                    .Like(p.Name, $"%{name}%"))
                .OrderBy(p => p.Id)
                .ToListAsync(cancellationToken);
        }
        catch (DbException e)
        {
            throw;
        }
    }
}