using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class OrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }
    
}