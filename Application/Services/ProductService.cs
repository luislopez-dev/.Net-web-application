using Application.Abstractions;
using Business.Models;

namespace Application.Services;

public class ProductService: IProductService
{
    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void UpdateInvoice(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProduct()
    {
        throw new NotImplementedException();
    }
}