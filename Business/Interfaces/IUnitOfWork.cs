namespace Business.Interfaces;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    IInvoiceRepository InvoiceRepository { get; }
    Task<bool> CompleteAsync();
    bool HasChanges();
}