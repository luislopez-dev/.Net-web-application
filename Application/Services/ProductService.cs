using Application.Abstractions;
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
    public void AddProduct(Product product)
    {
        _unitOfWork.ProductRepository.AddProduct(product);
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