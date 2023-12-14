using Business.Models;

namespace Business.Interfaces;

public interface IProductRepository
{
    public void AddProduct(Product product);
    public void DeleteProduct(Product product);
    public void UpdateInvoice(Product product);
    public Task<List<Product>> GetProducts();
    public Task<Product> GetProduct();
}