using Business.Interfaces;

namespace Application.Abstractions;

public interface IServiceManager
{
   IProductService ProductService { get; }
   IInvoiceService InvoiceService { get; }
}