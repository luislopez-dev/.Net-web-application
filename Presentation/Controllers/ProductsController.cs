using Application.Abstractions;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ProductsController : BaseController
{
    private readonly IServiceManager _serviceManager;
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IServiceManager serviceManager, IUnitOfWork unitOfWork)
    {
        _serviceManager = serviceManager;
        _unitOfWork = unitOfWork;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public void Delete(int? id)
    {
    }

    public IActionResult Details(int? id)
    {
        return View();
    }

    public IActionResult Edit(int? id)
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name, Price, Stock, Description")]Product product)
    {
        if (!ModelState.IsValid) return View(product);
        
        _serviceManager
            .ProductService
            .AddProduct(product);

        await _unitOfWork.Complete();
        
        return RedirectToAction(nameof(Index));
    }
}