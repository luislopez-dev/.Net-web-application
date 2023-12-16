using Application.Abstractions;
using Business.Interfaces;

namespace Application.Services;

public sealed class ServiceManager: IServiceManager
{
    private readonly IUnitOfWork _unitOfWork;

    public ServiceManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IProductService ProductService => new ProductService(_unitOfWork);
    public IInvoiceService InvoiceService => new InvoiceService(_unitOfWork);
}