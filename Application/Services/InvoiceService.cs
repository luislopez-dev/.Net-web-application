using System.Transactions;
using Application.Abstractions;
using Business.Interfaces;
using Business.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Services;

public class InvoiceService: IInvoiceService
{
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(IUnitOfWork unitOfWork, ILogger<InvoiceService> logger)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddInvoiceAsync(Invoice invoice, int[] selectedProducts, CancellationToken cancellationToken)
    { 
        cancellationToken.ThrowIfCancellationRequested();

        // Begin Transaction
        await using var transaction = _unitOfWork
            .BeginTransaction(cancellationToken);
        
        try
        {
            // Create Invoice
            await _unitOfWork
                .InvoiceRepository
                .AddInvoice(invoice, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        
            // Assign products to newly created invoice
            await _unitOfWork
                .InvoiceProductRepository
                .CreateRecordAsync(invoice.Id, selectedProducts, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            
            // Commit transaction if previous operations succeed
            await transaction.CommitAsync(cancellationToken);
        }
        catch (TransactionException e)
        {
            await transaction.RollbackAsync(cancellationToken);
        }
    }
    public async Task<List<Invoice>> GetInvoicesPaginatedAsync()
    {
        return await _unitOfWork
            .InvoiceRepository
            .GetInvoicesPaginatedAsync();
    }
}