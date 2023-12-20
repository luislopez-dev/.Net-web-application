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

    public InvoicesController(IUnitOfWork unitOfWork, IInvoiceService invoiceService, IProductService productService)
    {
        _unitOfWork = unitOfWork;
        _invoiceService = invoiceService;
        _productService = productService;
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
    public async Task<IActionResult> Create([Bind("ClientName", "ClientNit", "PaymentMethod", "ClientAddress")] Invoice invoice, int[] selectedProducts)
    {
        if (!ModelState.IsValid)
        {
            TempData["message"] = "Campos invalidos!";
            return View(nameof(Index));
        }
        
        await _invoiceService.AddInvoice(invoice, selectedProducts);
        
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