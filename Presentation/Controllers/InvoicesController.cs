using Application.Abstractions;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class InvoicesController : BaseController
{
    private readonly IServiceManager _serviceManager;
    
    private readonly IUnitOfWork _unitOfWork;

    public InvoicesController(IServiceManager serviceManager, IUnitOfWork unitOfWork)
    {
        _serviceManager = serviceManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _serviceManager
            .InvoiceService
            .GetInvoicesAsync();
        
        return View(products);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ClientName", "ClientNit", "Products", "PaymentMethod", "ClientAddress")] Invoice invoice)
    {
        if (ModelState.IsValid!) return View(nameof(Index));
        
        _serviceManager.InvoiceService.AddInvoice(invoice);

        await _unitOfWork.CompleteAsync();
            
        return View(nameof(Index));
    }
}