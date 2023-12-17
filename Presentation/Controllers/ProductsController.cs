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
    
    public async Task<IActionResult> Index()
    {
        var products = await _serviceManager
            .ProductService
            .GetProductsPaginatedAsync();
        
        return View(products);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Product product)
    {
        _serviceManager.ProductService.DeleteProduct(product);

        if (await _unitOfWork.CompleteAsync())
        {
            TempData["message"] = "Producto eliminado exitosamente";
            
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

   
    public async Task<IActionResult> Details(int id)
    {
        var product = await _serviceManager.
            ProductService
            .GetProductByIdAsync(id);
        
        return View(product);
    }

  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Product product)
    {
        _serviceManager
            .ProductService
            .UpdateProduct(product);

        if (await _unitOfWork.CompleteAsync())
        {
            TempData["message"] = "Producto actualizado exitosamente!";
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _serviceManager.ProductService.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name, Price, Stock, Description")]Product product)
    {
        if (!ModelState.IsValid) return View(product);
        
        _serviceManager
            .ProductService
            .AddProduct(product);

        if(await _unitOfWork.CompleteAsync())
        {
            TempData["message"] = "Producto creado exitosamente!";
            return RedirectToAction(nameof(Index));
        };
        return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
        return View();
    }
    
    public async Task<IActionResult> Search(string productName)
    {
        var products = await _serviceManager
            .ProductService
            .GetProductsByNamePaginated(productName);
        
        return View("Index", products);
    }
}