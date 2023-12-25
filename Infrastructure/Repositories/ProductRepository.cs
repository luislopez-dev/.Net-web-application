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
        
        await _context.AddAsync(product, cancellationToken);
    }
    public async Task DeleteProductByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var product = await _context.Products
            .FirstOrDefaultAsync(m => m.Guid == guid, cancellationToken);
        _context.Remove(product);
    }
    public void UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        _context.Entry(product).State = EntityState.Modified;
    }
    public async Task<List<Product>> GetProductsPaginatedAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var products = from n in _context.Products select n;
        
        return await products.ToListAsync(cancellationToken);
    }
    public async Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context
            .Products
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task<Product> GetProductByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        return await _context
            .Products
            .FirstOrDefaultAsync(m => m.Guid == guid, cancellationToken);
    }

    public async Task<List<Product>> GetProductsByNamePaginated(string name, CancellationToken cancellationToken)
    {
        return await _context
            .Products
            .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
            .OrderBy(p => p.Id)
            .ToListAsync(cancellationToken);
    }
}