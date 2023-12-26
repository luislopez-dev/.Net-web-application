using System.Transactions;
using Business.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    public IProductRepository ProductRepository => new ProductRepository(_context);
    public IInvoiceRepository InvoiceRepository => new InvoiceRepository(_context);
    public IInvoiceProductRepository InvoiceProductRepository => new InvoiceProductRepository(_context);

    public async Task<bool> CompleteAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public bool HasChanges()
    {
        try
        {
            return _context.ChangeTracker.HasChanges();
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IDbContextTransaction BeginTransaction(CancellationToken cancellationToken)
    {
        try
        {
            return _context.Database.BeginTransaction();
        }
        catch (TransactionException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}