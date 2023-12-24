﻿using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Interfaces;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    
    IInvoiceRepository InvoiceRepository { get; }
    
    IInvoiceProductRepository InvoiceProductRepository { get; }
    
    Task<bool> CompleteAsync();
    
    bool HasChanges();
    
    IDbContextTransaction BeginTransaction(CancellationToken cancellationToken);
    
}