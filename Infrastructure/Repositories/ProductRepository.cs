using Business.Interfaces;
using Business.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }
    public void AddProduct(Product product)
    {
        _context.Add(product);
    }
    public void DeleteProduct(Product product)
    {
        _context.Remove(product);
    }
    public void UpdateProduct(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
    }
    public async Task<List<Product>> GetProducts()
    {
        var products = from n in _context.Products select n;
        
        return await products.ToListAsync();
    }
    public async Task<Product> GetProduct(int id)
    {
        var product = await _context
            .Products
            .FirstOrDefaultAsync(m => m.Id == id);
        
        return product;
    }
}