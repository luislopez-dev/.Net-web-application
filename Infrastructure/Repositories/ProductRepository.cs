using Business.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }
}