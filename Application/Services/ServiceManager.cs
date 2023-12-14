using Application.Abstractions;
using Business.Interfaces;

namespace Application.Services;

public sealed class ServiceManager: IServiceManager
{
    public IProductService ProductService { get; }
    public IInvoiceService InvoiceService { get; }

    public ServiceManager(IProductService productService, IInvoiceService invoiceService)
    {
        ProductService = productService;
        InvoiceService = invoiceService;
    }
}