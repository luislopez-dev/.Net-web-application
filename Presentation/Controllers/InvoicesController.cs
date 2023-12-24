using Application.Abstractions;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class InvoicesController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInvoiceService _invoiceService;
    private readonly IProductService _productService;
    private readonly ILogger<InvoicesController> _logger;


    public InvoicesController(IUnitOfWork unitOfWork, IInvoiceService invoiceService, IProductService productService, ILogger<InvoicesController> logger)
    {
        _unitOfWork = unitOfWork;
        _invoiceService = invoiceService;
        _productService = productService;
        _logger = logger;
    }
    public async Task<IActionResult> Index()
    {
        var invoices = await _invoiceService
        .GetInvoicesPaginatedAsync();
        
        return View(invoices);
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.products = await _productService
            .GetProductsPaginatedAsync();
        
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ClientName", "ClientNit", "PaymentMethod", "ClientAddress")] Invoice invoice, 
        int[] selectedProducts, 
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            TempData["message"] = "Campos invalidos!";
            return View(nameof(Index));
        }
        try
        {
            await _invoiceService.AddInvoiceAsync(invoice, selectedProducts, cancellationToken);
        }
        catch (OperationCanceledException e)
        {
            _logger.LogInformation("Operación cancelada");
        }

        if(await _unitOfWork.CompleteAsync()){
            TempData["message"] = "Factura creada exitosamente!";
        }
        else
        {
            TempData["message"] = "Hubo un error en la creación de la factura!";
        }
        return RedirectToAction(nameof(Index));
    }
}