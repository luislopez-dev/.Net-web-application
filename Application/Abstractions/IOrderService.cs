using Business.Models;

namespace Application.Abstractions;

public interface IOrderService
{
    public void CreateOrder(Invoice invoice, int[] selectedProducts);
}