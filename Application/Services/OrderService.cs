using Application.Abstractions;
using Business.Interfaces;
using Business.Models;

namespace Application.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void CreateOrder(Invoice invoice, int[] selectedProducts)
    {
        
    }
}