using Application.Abstractions;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class InvoicesController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public InvoicesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var invoices = await _unitOfWork
            .InvoiceRepository
            .GetInvoicesPaginatedAsync();
        
        return View(invoices);
    }
    
    public async Task<IActionResult> Create()
    {
        ViewBag.products = await _unitOfWork
            .ProductRepository
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