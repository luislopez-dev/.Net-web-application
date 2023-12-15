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
        _unitOfWork.ProductRepository.DeleteProduct(product);
    }
    public void UpdateProduct(Product product)
    {
        _unitOfWork.ProductRepository.UpdateProduct(product);
    }
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _unitOfWork.ProductRepository.GetProductsAsync();
    }
    public async Task<Product> GetProductAsync(int id)
    {
        return await _unitOfWork.ProductRepository.GetProductAsync(id);
    }
}