namespace Application.Abstractions;

public interface IServiceManager
{
    IInvoiceService InvoiceService { get; }
    IProductService ProductService { get; }
}