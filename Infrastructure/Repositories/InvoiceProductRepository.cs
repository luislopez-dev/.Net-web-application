using Business.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

internal class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }
    public void CreateOrder(int invoiceId, int[] selectedProducts)
    {
        throw new NotImplementedException();
    }
}