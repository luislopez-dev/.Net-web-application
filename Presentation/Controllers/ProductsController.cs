using Application.Abstractions;
using Business.Exceptions.Product;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService productService, IUnitOfWork unitOfWork, ILogger<ProductsController> logger)
    {
        _productService = productService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var products = await _productService
            .GetProductsPaginatedAsync(cancellationToken);
        
        return View(products);
    }
    
    public ActionResult Create()
    {
        return View();
    }
    
    public async Task<IActionResult> Search(string productName, CancellationToken cancellationToken)
    {
        var products = await
            _productService
                .GetProductsByNamePaginatedAsync(productName, cancellationToken);
        
        return View("Index", products);
    }
    
    public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
    {
        var product = await 
            _productService
                .GetProductByGuidAsync(id, cancellationToken);
        if (product == null)
        {
            return RedirectToAction("NotFound", "Error");
        }
        return View(product);
    }
    
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var product = await 
                _productService
                    .GetProductByGuidAsync(id, cancellationToken);
        
            if (product == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(product);
        }
        catch (ProductNotFoundException e)
        {
            return RedirectToAction("NotFound", "Error");
        }
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task DeleteConfirmed([Bind("Guid")]Product product, CancellationToken cancellationToken)
    {
        try
        {
            await _productService
                .DeleteProductByGuidAsync(product.Guid, cancellationToken);

            if (true)
            {
                TempData["message"] = "Producto eliminado exitosamente";
            }
        }
        catch (Exception e)
        {
            TempData["message"] = "No se pudo eliminar el producto, intentelo más tarde";
            RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product product, CancellationToken cancellationToken)
    {
        try
        {
            _productService
                .UpdateProduct(product, cancellationToken);
            
            TempData["message"] = "!Producto actualizado exitosamente!";
        }
        catch (Exception e)
        {
            TempData["message"] = "!Error al actualizar el producto, inténtelo más tarde!";
        }
        return RedirectToAction(nameof(Details), new {product.Guid, cancellationToken});
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name, Price, Stock, Description")]Product product, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(product);
            
            await _productService
            .AddProductAsync(product, cancellationToken);

        if(true)
        {
            TempData["message"] = "Producto creado exitosamente!";
        };
        return RedirectToAction(nameof(Index));
    }
}