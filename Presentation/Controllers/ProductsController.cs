using Application.Abstractions;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IProductService productService, IUnitOfWork unitOfWork)
    {
        _productService = productService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService
            .GetProductsPaginatedAsync();
        
        return View(products);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Product product)
    {
        _productService
        .DeleteProduct(product);

        if (await _unitOfWork.CompleteAsync())
        {
            TempData["message"] = "Producto eliminado exitosamente";
            
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(Guid id)
    {
        Console.WriteLine(id);
        
        var product = await 
            _productService
            .GetProductByGuid(id);
        
        return View(product);
    }

  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Product product)
    {
        _productService
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

        var product = await 
            _productService
            .GetProductByIdAsync(id);

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
            
            _productService
            .AddProduct(product);

        if(await _unitOfWork.CompleteAsync())
        {
            TempData["message"] = "Producto creado exitosamente!";
        };
        return RedirectToAction(nameof(Index));
    }

    public ActionResult Create()
    {
        return View();
    }
    
    public async Task<IActionResult> Search(string productName)
    {
        var products = await
            _productService
            .GetProductsByNamePaginated(productName);
        
        return View("Index", products);
    }
}