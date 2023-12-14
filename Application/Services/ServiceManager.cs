using Application.Abstractions;
using Business.Interfaces;

namespace Application.Services;

public sealed class ServiceManager: IServiceManager

{
    public IInvoiceService InvoiceService { get; }
    public IProductService ProductService { get; }

    public ServiceManager(IInvoiceService invoiceService, IProductService productService)
    {
        InvoiceService = invoiceService;
        ProductService = productService;
    }
}