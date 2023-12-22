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
    public async Task AddProduct(Product product)
    {
        await _context.AddAsync(product);
    }
    public async Task DeleteProductByGuidAsync(Guid guid)
    {
        /* In case optimization is needed, use this:
         var sql = $"DELETE FROM Products WHERE Guid = {guid}";
         await _context.Database.ExecuteSqlRawAsync(sql);
        */
        var product = await _context.Products
            .FirstOrDefaultAsync(m => m.Guid == guid);
        _context.Remove(product);
    }
    public void UpdateProduct(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
    }
    public async Task<List<Product>> GetProductsPaginatedAsync()
    {
        var products = from n in _context.Products select n;
        
        return await products.ToListAsync();
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context
            .Products
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Product> GetProductByGuid(Guid guid)
    {
        return await _context
            .Products
            .FirstOrDefaultAsync(m => m.Guid == guid);
    }

    public async Task<List<Product>> GetProductsByNamePaginated(string name)
    {
        return await _context
            .Products
            .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
            .OrderBy(p => p.Id)
            .ToListAsync();
    }
}