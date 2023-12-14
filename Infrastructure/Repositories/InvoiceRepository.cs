using Business.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class InvoiceRepository: IInvoiceRepository
{
    private readonly DataContext _context;

    public InvoiceRepository(DataContext context)
    {
        _context = context;
    }
}